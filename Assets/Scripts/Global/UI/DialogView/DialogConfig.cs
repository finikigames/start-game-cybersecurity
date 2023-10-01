using System;
using System.Collections.Generic;
using UnityEngine;

namespace Global.UI.DialogView {
    [Serializable]
    public class DialogConfig {
        [SerializeField]
        private List<DialogData> _raw;
        
        private Dictionary<string, DialogData> _data;
        
        public Dictionary<string, DialogData> Data {
            get {
                if (_data == null) {
                    _data = new Dictionary<string, DialogData>();
                    foreach (var stringTo in _raw) {
                        _data.Add(stringTo.Id, stringTo);
                    }
                }
                
                return _data;
            }
        }
    }
}