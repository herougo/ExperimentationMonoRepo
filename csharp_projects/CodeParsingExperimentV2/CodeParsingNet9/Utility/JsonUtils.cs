using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CodeParsingNet9.Utility
{
    public static class JsonUtils
    {
        public static string GetPropertyString(JsonElement element, string key)
        {
            string? result = element.GetProperty(key).ToString();

            if (result is null)
            {
                throw new Exception($"Missing key: {key}");
            }

            return result;
        }
        public static int GetPropertyInt(JsonElement element, string key)
        {
            int? result = element.GetProperty(key).GetInt32();

            if (result is null)
            {
                throw new Exception($"Missing key: {key}");
            }

            return (int)result;
        }
    }
}
