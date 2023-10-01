using System;
using System.Collections.Generic;
using UnityEngine;

namespace Global.UI.StaticView {
    [Serializable]
    public class StaticConfig {
        [SerializeField]
        private List<StaticData> _raw;
        
        private Dictionary<string, StaticData> _data;
        
        public Dictionary<string, StaticData> Data {
            get {
                if (_data == null) {
                    _data = new Dictionary<string, StaticData>();
                    foreach (var stringTo in _raw) {
                        _data.Add(stringTo.Id, stringTo);
                    }
                }
                
                return _data;
            }
        }
    }
}