using System.Collections.Generic;
using RulesDoer.Core.Serialization;
using RulesDoer.Core.Transformer.v1_2;
using RulesDoer.Core.Validation;

namespace RulesDoer.Core.Repo {

    public class DMNRepository {
        private readonly DMNTransformer _dmnTransformer;
        private readonly IDMNPersistence _dmnPersistence;

        //TODO: Need to hook validation post transforming
        private readonly IDMNValidation _validation;

        //TODO: Add an interface for cache implementation - Example IMemcache

        public DMNRepository (DMNTransformer transformer, IDMNPersistence persistence, IDMNValidation validation) {
            _dmnTransformer = transformer;
            _dmnPersistence = persistence;
            _validation = validation;
        }

        public TDefinitions FindDefinitions (string definitionName, int? versionNo = null) {

            //TODO: Add cache solution

            var definitions = _dmnPersistence.ReadDefinitions (definitionName, versionNo);

            if (definitions is null) {
                throw new DMNException ($"No definition found for: {definitionName}");
            }

            //TODO: add validations

            return _dmnTransformer.Transform (definitions);
        }

        public void WriteDefinitions (TDefinitions definitions) {
            var definitionSerialized = _dmnTransformer.Transform (definitions);

            //TODO: add validations

            _dmnPersistence.WriteDefinitions (definitions.Name, definitionSerialized);
        }

    }
}