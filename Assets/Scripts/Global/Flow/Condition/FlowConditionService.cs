using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Global.Flow.Condition {
    public class FlowConditionService : IInitializable,
                                        ITickable {
        private Dictionary<string, BaseCondition> _conditions;

        public void Initialize() {
            _conditions = new Dictionary<string, BaseCondition>();
        }

        public void RegisterCondition(string conditionId, BaseCondition condition) {
            _conditions.Add(conditionId, condition);
        }

        public void UnregisterCondition(string conditionId) {
            _conditions.Remove(conditionId);
        }

        public bool CheckConditions(List<string> conditions) {
            foreach (var conditionId in conditions) {
                if (!_conditions.ContainsKey(conditionId)) {
                    Debug.LogWarning($"There is no condition with id {conditionId}");
                    continue;
                }
                var condition = _conditions[conditionId];

                if (!condition.Ready) return false;
            }

            return true;
        }

        public void Tick() {
            foreach (var condition in _conditions) {
                condition.Value.Check();
            }
        }
    }
}