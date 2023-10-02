using System;
using System.Collections.Generic;
using UnityEngine;

namespace Global.UI.ContinueView {
    [Serializable]
    public class ContinueConfig {
        [SerializeField]
        private List<ContinueData> _raw;
        
        private Dictionary<string, ContinueData> _data;
        
        public Dictionary<string, ContinueData> Data {
            get {
                if (_data == null) {
                    _data = new Dictionary<string, ContinueData>();
                    foreach (var stringTo in _raw) {
                        _data.Add(stringTo.Id, stringTo);
                    }
                }
                
                return _data;
            }
        }
    }
}