using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace RulesDoer.Core.Tests.TCK.Run {
    public class TCKFilesAttribute : DataAttribute {
        public readonly string _searchPath;
        private readonly HashSet<string> _excludedFilenames;

        public TCKFilesAttribute (string searchPath, params string[] excludedFilenames) {
            _searchPath = searchPath;
            _excludedFilenames = new HashSet<string> (excludedFilenames);
        }

        public override IEnumerable<object[]> GetData (MethodInfo testMethod) {

            var assembly = Assembly.GetExecutingAssembly ();
            var resourceNames = assembly.GetManifestResourceNames ();
            var result = new List<object[]> ();

            string xmlContent;
            foreach (var resourceName in resourceNames) {
                xmlContent = null;
                if (resourceName.Contains ($"DmnFiles.TCK.{_searchPath}") && resourceName.EndsWith ("xml")) {
                    var resourceSplit = resourceName.Split ('.');
                    var filename = resourceSplit[resourceSplit.Length - 2];
                    if (_excludedFilenames.Contains (filename))
                        continue;

                    var resourceStream = assembly.GetManifestResourceStream (resourceName);

                    using (TextReader textReader = new StreamReader (resourceStream, Encoding.UTF8)) {
                        xmlContent = textReader.ReadToEnd ();
                    }
                    yield return new object[] { filename, xmlContent };

                }
            }
        }
    }
}