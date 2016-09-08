using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ILMerge.MsBuild.Task
{

    [DataContract]
    public class AdvancedSettings
    {

        #region Property Wrappers

        [DataMember]
        public bool AllowMultipleAssemblyLevelAttributes { get; set; } = false;

        [DataMember]
        public bool AllowWildCards { get; set; } = false;

        [DataMember]
        public bool AllowZeroPeKind { get; set; } = false;

        [DataMember]
        public string AttributeFile { get; set; } = null;

        [DataMember]
        public bool Closed { get; set; } = false;

        [DataMember]
        public bool CopyAttributes { get; set; } = false;

        [DataMember]
        public bool DebugInfo { get; set; } = true;

        [DataMember]
        public bool DelaySign { get; set; } = false;

        [DataMember]
        public string ExcludeFile { get; set; } = string.Empty;

        [DataMember]
        public int FileAlignment { get; set; } = 512;

        [DataMember]
        public bool Internalize { get; set; } = false;

        [DataMember]
        public bool Log { get; set; } = false;

        [DataMember]
        public string LogFile { get; set; } = null;

        [DataMember]
        public bool PublicKeyTokens { get; set; } = true;

        [DataMember]
        public string TargetKind { get; set; } = null;

        [DataMember]
        public bool UnionMerge { get; set; } = false;

        [DataMember]
        public string Version { get; set; } = null;

        [DataMember]
        public bool XmlDocumentation { get; set; } = false;

        #endregion

        #region Method Wrappers

        /// <summary>
        /// Default is none. This option allows the user to either allow all public types to be renamed when they are duplicates, or to specify it for arbitrary type names.
        /// </summary>
        [DataMember]
        public string AllowDuplicateType { get; set; } = null;

        /// <summary>
        /// internal use
        /// </summary>
        [DataMember]
        public List<string> SearchDirectories { get; set; }

        #endregion

        #region Constructors

        public AdvancedSettings()
        {
            SearchDirectories = new List<string>();
        }

        #endregion

    }
}
