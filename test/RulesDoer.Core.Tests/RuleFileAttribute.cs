using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace RulesDoer.Core.Tests {
    [AttributeUsage (AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class RuleFileAttribute : DataAttribute {
        public string FileName { get; }

        public RuleFileAttribute (string fileName) {
            FileName = fileName;
        }

        public override IEnumerable<object[]> GetData (MethodInfo testMethod) {

            var assembly = Assembly.GetExecutingAssembly ();
            var resourceStream = assembly.GetManifestResourceStream ($"RulesDoer.Core.Tests.{FileName}");

            string xmlContent;
            using (TextReader textReader = new StreamReader (resourceStream, Encoding.UTF8)) {
                xmlContent = textReader.ReadToEnd ();
            }

            object[] result = new object[1];
            result[0] = xmlContent;
            yield return result;
        }

    }
}