using Microsoft.Build.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace ILMerge.MsBuild.Task
{
    class FrameworkInfo
    {

        public static bool TryParseVersion(string version, out TargetDotNetFrameworkVersion frameworkVersion)
        {

            if (string.IsNullOrWhiteSpace(version))
                throw new ArgumentNullException(nameof(version));

            version = version.ToLower().Replace("v", string.Empty).Replace(".", string.Empty);

            if(version.Length > 2)
                version = version.Substring(0, 2);

            switch (version)
            {
                case "1":
                case "10":
                case "11":
                    frameworkVersion = TargetDotNetFrameworkVersion.Version11;
                    return true;
                case "2":
                case "20":
                    frameworkVersion = TargetDotNetFrameworkVersion.Version20;
                    return true;
                case "3":
                case "30":
                    frameworkVersion = TargetDotNetFrameworkVersion.Version30;
                    return true;
                case "35":
                    frameworkVersion = TargetDotNetFrameworkVersion.Version35;
                    return true;
                case "4":
                case "40":
                    frameworkVersion = TargetDotNetFrameworkVersion.Version40;
                    return true;
                case "45":
                case "46":
                    frameworkVersion = TargetDotNetFrameworkVersion.Version45;
                    return true;
            }

            string svalue = string.Format("Version{0}", version);

            return Enum.TryParse<TargetDotNetFrameworkVersion>(svalue, out frameworkVersion);

        }

        public static bool TryParsePlatform(string architecture, out DotNetFrameworkArchitecture frameworkArchitecture)
        {

            if (string.IsNullOrWhiteSpace(architecture))
                throw new ArgumentNullException(nameof(architecture));

            string svalue = string.Format(
                "Bitness{0}",
                architecture.ToLower().Replace("v", string.Empty).Replace(".", string.Empty)
                 );

            return Enum.TryParse<DotNetFrameworkArchitecture>(svalue, out frameworkArchitecture);

        }

        public static string GetPathToDotNetFramework(TargetDotNetFrameworkVersion version)
        {
            return ToolLocationHelper.GetPathToDotNetFramework(version);
        }

        public static string GetPathToDotNetFramework(TargetDotNetFrameworkVersion version, DotNetFrameworkArchitecture architecture)
        {
            return ToolLocationHelper.GetPathToDotNetFramework(version, architecture);
        }

        public static string ToILmergeTargetPlatform(string version, string architecture)
        {

            if (string.IsNullOrWhiteSpace(version))
                throw new ArgumentNullException(nameof(version));

            string path;
            TargetDotNetFrameworkVersion fversion;
            DotNetFrameworkArchitecture farchitecture;

            if (!FrameworkInfo.TryParseVersion(version, out fversion))
            {
                throw new ArgumentOutOfRangeException(nameof(version), $"Unable to parse .Net framework version: {version}");
            }

            if (string.IsNullOrWhiteSpace(architecture))
            {
                path = FrameworkInfo.GetPathToDotNetFramework(fversion);
            }
            else
            {
                if(FrameworkInfo.TryParsePlatform(architecture, out farchitecture))
                {
                    path = FrameworkInfo.GetPathToDotNetFramework(fversion, farchitecture);
                }
                else
                {
                    path = FrameworkInfo.GetPathToDotNetFramework(fversion);
                }
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                throw new Exception($"Unable to resolve .Net Framework directory. Framework version: {version}");
            }

            return $"{VersionToString(fversion)},{path}";

        }

        private static string VersionToString(TargetDotNetFrameworkVersion version)
        {

            switch (version)
            {
                case TargetDotNetFrameworkVersion.Version11: return "v1.1";
                case TargetDotNetFrameworkVersion.Version20: return "v2";
                case TargetDotNetFrameworkVersion.Version30: return "v2";
                case TargetDotNetFrameworkVersion.Version35: return "v2";
                case TargetDotNetFrameworkVersion.Version40: return "v4";
                case TargetDotNetFrameworkVersion.Version45: return "v4";
                default: return "v4";
            }

        }

    }
}
