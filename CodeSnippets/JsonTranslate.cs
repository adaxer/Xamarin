using Books.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Linq;

namespace Books.Services.i18n
{
    public class JsonTranslate : ITranslate
    {
        string _dict;

        public JsonTranslate(IResourceLoader loader, string language)
        {
            _dict = loader.Load($"Services/i18n/{language}.json").Replace("{{value}}", "{0}");
        }

        public string Get(string key, params string[] args)
        {
            var formatOrResult = GetRecursive(_dict, key.Split('.'));
            if(args.Length==0)
            {
                return formatOrResult.Success ? formatOrResult.Value : $"??{key}??";
            }
            var parameters = args.Select(arg => Get(arg)).ToArray();
            string result = $"??{key}??";
            try
            {
                result = string.Format(formatOrResult.Value, parameters);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return result;
        }

        private (bool Success, string Value) GetRecursive(string dict, string[] keys)
        {
            JObject json = JsonConvert.DeserializeObject(dict) as JObject;
            if (json == null)
            {
                return (false, string.Empty);
            }

            if (keys.Length == 1)
            {
                if(json[keys.First()] is JToken jt)
                {
                    return (true, jt.ToString());
                }
                return (false, string.Empty);
            }

            json.TryGetValue(keys.First(), out JToken newObj);
            if (newObj == null)
            {
                return (false, string.Empty);
            }

            return GetRecursive(newObj.ToString(), keys.Skip(1).ToArray());
        }
    }
}
