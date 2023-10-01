using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Global.Flow.Condition {
    public class FlowConditionService : IInitializable,
                                        ITickable {
        private Dictionary<string, BaseCondition> _conditions;

        public void Initialize() {
            _conditions = new Dictionary<string, BaseCondition>();
            
            RegisterCondition("screen_click", new ScreenClickCondition());
        }

        public void RegisterCondition(string conditionId, BaseCondition condition) {
            _conditions.Add(conditionId, condition);
        }

        public void UnregisterCondition(string conditionId) {
            _conditions.Remove(conditionId);
        }

        public bool CheckConditions(List<string> conditions) {
            int readyCount = 0;
            
            foreach (var conditionId in conditions) {
                if (!_conditions.ContainsKey(conditionId)) {
                    Debug.LogWarning($"There is no condition with id {conditionId}");
                    continue;
                }
                var condition = _conditions[conditionId];

                if (condition.Ready) readyCount++;
            }

            return readyCount == conditions.Count;
        }

        public void Tick() {
            foreach (var condition in _conditions) {
                condition.Value.Check();
            }
        }
    }
}