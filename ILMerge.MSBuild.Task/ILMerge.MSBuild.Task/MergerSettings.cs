using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace ILMerge.MsBuild.Task
{

    [DataContract]
    [KnownType(typeof(AdvancedSettings))]
    [KnownType(typeof(GeneralSettings))]
    public class MergerSettings
    {

        [DataMember(Order = 0)]
        public GeneralSettings General { get; set; } = new GeneralSettings();

        [DataMember(Order = 1)]
        public AdvancedSettings Advanced { get; set; } = new AdvancedSettings();

        public string ToJson()
        {

            string jsonString;

            using (MemoryStream stream = new MemoryStream())
            {

                var s = new DataContractJsonSerializerSettings()
                {
                    EmitTypeInformation = EmitTypeInformation.AsNeeded
                };

                var ds = new DataContractJsonSerializer(typeof(MergerSettings), s);

                ds.WriteObject(stream, this);
                jsonString = Encoding.UTF8.GetString(stream.ToArray());

            }

            return jsonString;

        }

        public static MergerSettings FromJson(string jsonString)
        {

            if (string.IsNullOrWhiteSpace(jsonString)) throw new ArgumentNullException(nameof(jsonString));

            MergerSettings results = null;

            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
            {
                var serializer = new DataContractJsonSerializer(typeof(MergerSettings));
                results = (MergerSettings) serializer.ReadObject(ms);
            }

            return results;

        }


    }
}
