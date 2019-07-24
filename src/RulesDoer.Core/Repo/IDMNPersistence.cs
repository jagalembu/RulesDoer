namespace RulesDoer.Core.Repo {
    public interface IDMNPersistence {

        string ReadDefinitions (string definitionName, int? versionNo = null);

        void WriteDefinitions (string definitionName, string dmn);

    }

}