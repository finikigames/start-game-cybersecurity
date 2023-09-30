using System;
using System.Collections.Generic;
using UnityEngine;

namespace Global.UI.InteractableView {
    [Serializable]
    public class InteractableConfig {
        [SerializeField]
        private List<InteractableData> _raw;
        
        private Dictionary<string, InteractableData> _data;
        
        public Dictionary<string, InteractableData> Data {
            get {
                if (_data == null) {
                    _data = new Dictionary<string, InteractableData>();
                    foreach (var stringTo in _raw) {
                        _data.Add(stringTo.Id, stringTo);
                    }
                }
                
                return _data;
            }
        }
    }
}