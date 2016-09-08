using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ILMerge.MsBuild.Task
{

    [DataContract]
    public class GeneralSettings
    {

        [DataMember(Order = 1)]
        public string OutputFile { get; set; } = null;

        [DataMember(Order = 2)]
        public string TargetPlatform { get; set; } = null;

        [DataMember(Order = 3)]
        public string KeyFile { get; set; } = null;

        [DataMember(Order = 4)]
        public string AlternativeILMergePath { get; set; } = null;

        [DataMember(Order = 5)]
        public List<string> InputAssemblies { get; set; }

        public GeneralSettings()
        {
            InputAssemblies = new List<string>();
        }

    }
}
