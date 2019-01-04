using System.Collections.Generic;
using System.Threading.Tasks;
using RulesDoer.Core.Transformer;

namespace RulesDoer.Core.Validation
{
    public interface DMNValidation
    {
        Task<List<string>> Validate(TDefinitions definition);
    }
}