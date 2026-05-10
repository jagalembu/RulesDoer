using RulesDoer.Core.Repo;
using Xunit;

namespace RulesDoer.Core.Tests.Repo {
    public class DefaultDMNPersistenceTests {
        // Use a key that DMNFixture never writes so version numbering starts from 1
        private const string TestKey = "test-persistence-isolation-key";

        [Theory]
        [RuleFile ("Repo.Files.inputdatastring.dmn")]
        public void WriteDefinitions_ReadDefinitions (string inputRule) {
            var dmnPersist = DefaultDMNPersistence.Instance;
            dmnPersist.WriteDefinitions (TestKey, inputRule);

            var definition = dmnPersist.ReadDefinitions (TestKey);

            Assert.NotNull (definition);
            Assert.Equal<string> (inputRule, definition);

            dmnPersist.WriteDefinitions (TestKey, inputRule);
            definition = dmnPersist.ReadDefinitions (TestKey, 2);

            Assert.NotNull (definition);
            Assert.Equal<string> (inputRule, definition);

            dmnPersist.WriteDefinitions (TestKey, inputRule);
            definition = dmnPersist.ReadDefinitions (TestKey, 5);

            Assert.Null (definition);

        }

    }
}