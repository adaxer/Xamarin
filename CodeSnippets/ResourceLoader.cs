using Books.Interfaces;
using System.IO;
using System.Reflection;

namespace Books.Services
{
    public class ResourceLoader : IResourceLoader
    {
        Assembly _assembly;
        string _resourceBase;

        public ResourceLoader()
        {
            _assembly = IntrospectionExtensions.GetTypeInfo(typeof(ResourceLoader)).Assembly;
            _resourceBase = _assembly.GetName().Name + "."; 
        }
        public string Load(string filePath)
        {
            string resourcePath = $"{_resourceBase}{filePath.Replace('/', '.').Replace('\\', '.')}";
            Stream stream = _assembly.GetManifestResourceStream(resourcePath);

            string text = "";
            using (var reader = new StreamReader(stream))
            {
                text = reader.ReadToEnd();
            }
            return text;
        }
    }
}
