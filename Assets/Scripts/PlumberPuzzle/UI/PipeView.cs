using System;
using PlumberPuzzle.Config;
using PlumberPuzzle.Data;
using UnityEngine;
using UnityEngine.UI;

namespace PlumberPuzzle.UI {
    public class PipeView : MonoBehaviour {
        [SerializeField] private Button _pipeButton;
        [SerializeField] private Image _pipeIcon;

        public PipeData Data;
        public int Index;

        public void Initialize(Sprite icon, Action<int> callback, int index, PipeType type) {
            Index = index;
            
            _pipeButton.interactable = true;
            _pipeIcon.enabled = true;
            
            _pipeButton.onClick.RemoveAllListeners();
            _pipeButton.onClick.AddListener(() => callback?.Invoke(Index));

            _pipeIcon.sprite = icon;
            Data = new PipeData {
                ConnectedCells = new (),
                ConnectionType = type,
                Rotation = PipeRotationType.ZeroR
            };
        }

        public void RotatePipe() {
            if (Data.Rotation == PipeRotationType.ThreeR) {
                _pipeIcon.transform.rotation = new Quaternion();
                Data.Rotation = PipeRotationType.ZeroR;
                return;
            }
            
            _pipeIcon.transform.Rotate(0f, 0f, 90f);
            Data.Rotation = (PipeRotationType)((int)Data.Rotation + 1);
        }

        public void Hide() {
            _pipeButton.interactable = false;
            _pipeIcon.enabled = false;
        }
    }
}