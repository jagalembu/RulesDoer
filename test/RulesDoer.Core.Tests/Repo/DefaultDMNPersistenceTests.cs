using RulesDoer.Core.Repo;
using Xunit;

namespace RulesDoer.Core.Tests.Repo {
    public class DefaultDMNPersistenceTests {

        [Theory]
        [RuleFile ("Repo.Files.inputdatastring.dmn")]
        public void WriteDefinitions_ReadDefinitions (string inputRule) {
            var dmnPersist = DefaultDMNPersistence.Instance;
            dmnPersist.WriteDefinitions ("0001-input-data-string", inputRule);

            var definition = dmnPersist.ReadDefinitions ("0001-input-data-string");

            Assert.NotNull (definition);
            Assert.Equal<string> (inputRule, definition);

            dmnPersist.WriteDefinitions ("0001-input-data-string", inputRule);
            definition = dmnPersist.ReadDefinitions ("0001-input-data-string", 2);

            Assert.NotNull (definition);
            Assert.Equal<string> (inputRule, definition);

            dmnPersist.WriteDefinitions ("0001-input-data-string", inputRule);
            definition = dmnPersist.ReadDefinitions ("0001-input-data-string", 5);

            Assert.Null (definition);

        }

    }
}