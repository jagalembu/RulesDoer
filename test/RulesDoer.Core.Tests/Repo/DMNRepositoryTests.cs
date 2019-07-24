using RulesDoer.Core.Transformer.v1_2;
using Xunit;

namespace RulesDoer.Core.Tests.Repo {
    public class DMNRepositoryTests : IClassFixture<DMNFixture> {
        private readonly DMNFixture _fixture;

        public DMNRepositoryTests (DMNFixture fixture) {
            _fixture = fixture;
        }

        [Fact]
        public void FindDefinitions_NotFound () {
            var exp = Assert.Throws<DMNException> (() => _fixture._dmnRepository.FindDefinitions ("0001-input-data-stringX"));
            Assert.Equal ("No definition found for: 0001-input-data-stringX", exp.Message);
        }

        [Fact]
        public void FindDefinitions_No_Version () {
            var def = _fixture._dmnRepository.FindDefinitions ("0001-input-data-string");
            Assert.NotNull (def);
            Assert.Equal<string> ("0001-input-data-string", def.Name);
        }

        [Fact]
        public void FindDefinitions_With_Version () {
            var def = _fixture._dmnRepository.FindDefinitions ("0001-input-data-string", 1);
            Assert.NotNull (def);
            Assert.Equal<string> ("0001-input-data-string", def.Name);

        }

        [Fact]
        public void WriteDefinitions_With_Version () {

            var definitions = new TDefinitions { Name = "test_writedefinition" };

            _fixture._dmnRepository.WriteDefinitions (definitions);

            var def = _fixture._dmnRepository.FindDefinitions ("test_writedefinition", 1);
            Assert.NotNull (def);
            Assert.Equal<string> ("test_writedefinition", def.Name);

        }

    }
}