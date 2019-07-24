using System.Collections.Concurrent;
using System.Collections.Generic;

namespace RulesDoer.Core.Repo {
    public class DefaultDMNPersistence : IDMNPersistence {
        private ConcurrentDictionary<string, Dictionary<int, string>> _dmnDict = new ConcurrentDictionary<string, Dictionary<int, string>> ();
        private static readonly DefaultDMNPersistence _instance = new DefaultDMNPersistence ();

        static DefaultDMNPersistence () { }
        private DefaultDMNPersistence () { }

        public static DefaultDMNPersistence Instance {
            get {
                return _instance;
            }
        }

        public string ReadDefinitions (string definitionName, int? versionNo = null) {
            _dmnDict.TryGetValue (definitionName, out var dmns);

            if (dmns is null)
            {
                return null;
            }

            string definitionItem;

            if (versionNo.HasValue) {
                dmns.TryGetValue (versionNo.Value, out definitionItem);
                return definitionItem;

            }
            dmns.TryGetValue (dmns.Count, out definitionItem);

            return definitionItem;
        }

        public void WriteDefinitions (string definitionName, string dmn) {
            _dmnDict.TryGetValue (definitionName, out var dmns);

            if (dmns is null) {
                _dmnDict.TryAdd (definitionName, new Dictionary<int, string> () { { 1, dmn } });
                return;
            }
            dmns.TryAdd (dmns.Count + 1, dmn);
        }
    }
}