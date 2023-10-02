using System;
using System.Collections.Generic;
using UnityEngine;

namespace Global.UI.FullScreenView {
    [Serializable]
    public class FullScreenConfig {
        [SerializeField]
        private List<FullScreenData> _raw;
        
        private Dictionary<string, FullScreenData> _data;
        
        public Dictionary<string, FullScreenData> Data {
            get {
                if (_data == null) {
                    _data = new Dictionary<string, FullScreenData>();
                    foreach (var stringTo in _raw) {
                        _data.Add(stringTo.Id, stringTo);
                    }
                }
                
                return _data;
            }
        }
    }
}