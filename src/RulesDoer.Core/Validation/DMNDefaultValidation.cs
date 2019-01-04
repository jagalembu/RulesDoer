using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RulesDoer.Core.Transformer;

namespace RulesDoer.Core.Validation {
    public class DMNDefaultValidation : DMNValidation {
        private readonly ILogger<DMNDefaultValidation> _logger;

        public DMNDefaultValidation (ILogger<DMNDefaultValidation> logger) {
            _logger = logger;
        }
        public async Task<List<string>> Validate (TDefinitions definition) {

            var errorList = await DuplicateChecks (definition);

            return errorList;
        }

        private Task<List<string>> DuplicateChecks (TDefinitions definition) {
            var errorList = new List<string> ();

            errorList.AddRange (CheckDuplicates (definition.DrgElement.GroupBy (e => e.Id).Where (c => c.Count () > 1), "Element Id"));
            errorList.AddRange (CheckDuplicates (definition.DrgElement.GroupBy (e => e.Name).Where (c => c.Count () > 1), "Element Name"));
            errorList.AddRange (CheckDuplicates (definition.ItemDefinition.GroupBy (e => e.Name).Where (c => c.Count () > 1), "Item Definition Name"));

            return Task.FromResult (errorList);

        }

        private List<string> CheckDuplicates<T> (T items, string errorEleName) where T : IEnumerable<IGrouping<string, object>> {

            var errorList = new List<string> ();
            foreach (var item in items) {
                errorList.Add ($"Duplicate {errorEleName} name found: {item.Key}");

            }
            return errorList;
        }

    }
}