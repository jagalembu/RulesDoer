using System.Collections.Generic;
using System.Threading.Tasks;
using RulesDoer.Core.Transformer.v1_2;

namespace RulesDoer.Core.Validation {
    public interface IDMNValidation {
        Task<List<string>> Validate (TDefinitions definition);
    }
}