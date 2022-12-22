using System;
using Newtonsoft.Json;

namespace BloodeAPI.Utilities
{
    public static class JsonHelper
    {
        public static T? LoadJson<T>(string file)

        {
            using (StreamReader r = new StreamReader(file))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<T>(json);
            }

        }
    }
}

