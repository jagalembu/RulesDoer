using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace RulesDoer.Core.Tests.TCK.Run {
    public class TCKFilesAttribute : DataAttribute {
        public readonly string _searchPath;

        public TCKFilesAttribute (string searchPath) {
            _searchPath = searchPath;
        }

        public override IEnumerable<object[]> GetData (MethodInfo testMethod) {

            var assembly = Assembly.GetExecutingAssembly ();
            var resourceNames = assembly.GetManifestResourceNames ();
            var result = new List<object[]> ();

            string xmlContent;
            foreach (var resourceName in resourceNames) {
                xmlContent = null;
                if (resourceName.Contains ($"DmnFiles.TCK.{_searchPath}") && resourceName.EndsWith ("xml")) {
                    var resourceStream = assembly.GetManifestResourceStream (resourceName);

                    using (TextReader textReader = new StreamReader (resourceStream, Encoding.UTF8)) {
                        xmlContent = textReader.ReadToEnd ();
                    }
                    var resourceSplit = resourceName.Split ('.');
                    yield return new object[] { resourceSplit[resourceSplit.Length - 2], xmlContent };

                }
            }
        }
    }
}