using System.Collections.Generic;
using Global.Extensions;
using Global.UI;
using UnityEngine;

namespace Global.Flow {
    public class FlowSceneSettings : MonoBehaviour {
        [SerializeField]
        private List<StringToBaseWindow> _windowsRaw;

        private Dictionary<string, BaseWindow> _windows;
        
        public Dictionary<string, BaseWindow> Windows {
            get {
                if (_windows == null) {
                    _windows = new Dictionary<string, BaseWindow>();
                    foreach (var stringTo in _windowsRaw) {
                        _windows.Add(stringTo.Id, stringTo.Window);
                    }
                }
                
                return _windows;
            }
        }
    }
}