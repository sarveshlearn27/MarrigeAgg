using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarrigeAggrigator.Core.Utility
{
    public class FileReader
    {
        public static T GetDetails<T>(string filePath)
        {
            var appDomain = System.AppDomain.CurrentDomain;
            var basePath = appDomain.RelativeSearchPath ?? appDomain.BaseDirectory;
            var completedPath = basePath + filePath;
            var matrimonyWebsitesFromFile = File.ReadAllText(completedPath);
            return JsonConvert.DeserializeObject<T>(matrimonyWebsitesFromFile);
        }

    }
}
