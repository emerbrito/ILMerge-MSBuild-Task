using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ILMerge.MsBuild.Task
{
    static class ExeLocationHelper
    {

        public static bool TryILMergeInSolutionDir(string solutionDir, out string executablePath)
        {

            executablePath = null;
            string basePath = Path.Combine(solutionDir, "packages");

            // retrieve all ILMerge directories (can have multiple versions)
            IEnumerable<string> dirs = Directory.EnumerateDirectories(basePath, "ILMerge.*", SearchOption.TopDirectoryOnly);
            if (dirs == null || dirs.Count() == 0)
            {
                return false;
            }

            // sort by verion number and retrieve latest
            string latestVersionDir = Directory.EnumerateDirectories(basePath, "ILMerge.*", SearchOption.TopDirectoryOnly)
                .OrderByDescending(d => ExtractVersionFromName(Path.GetFileName(d)))
                .FirstOrDefault();

            // check presence of executable
            if (TryValidateILMergePath(latestVersionDir, out executablePath))
            {
                return true;
            }

            executablePath = null;
            return false;

        }

        public static string ExtractVersionFromName(string nameWithVersion)
        {

            Regex patern = new Regex(@"\.\d+(\.\d+)+", RegexOptions.RightToLeft);
            Match m = patern.Match(nameWithVersion);
            string version = m.Value.Replace(".", "");

            return version;

        }

        public static bool TryValidateILMergePath(string basePath, out string executablePath)
        {

            executablePath = null;
            string fullPath = Path.Combine(basePath, @"ILMerge.exe");

            if (File.Exists(fullPath))
            {
                executablePath = fullPath;
                return true;
            }

            fullPath = Path.Combine(basePath, "tools", @"ILMerge.exe");
            if (File.Exists(fullPath))
            {
                executablePath = fullPath;
                return true;
            }

            return false;

        }


    }
}
