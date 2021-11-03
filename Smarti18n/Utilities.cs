using System;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Smarti18n
{
    public static class Utilities
    {
        public static void GenerateTranslationFolder<T>(string[] LangCodes, string LangDir = "Languages")
        {
            var jsonTxt = "{}";

            if (typeof(T).IsClass)
            {
                var valuePairs = new JObject();
                typeof(T).GetProperties().ToList().ForEach(propInfo => valuePairs.Add(propInfo.Name, null));

                jsonTxt =  valuePairs.ToString(Formatting.Indented);
            }

            //Write into files
            if (!Directory.Exists(LangDir)) Directory.CreateDirectory(LangDir);

            LangCodes.ToList().ForEach(LangCode =>
            {
                File.WriteAllText(Path.Join(LangDir, $"{LangCode}.json"), jsonTxt);
            });
        }
    }
}
