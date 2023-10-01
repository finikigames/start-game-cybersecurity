using System;
using System.Collections.Generic;
using Global.UI;
using Main.Configs;
using Main.Services;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Main.UI.PasswordView {
    public class PasswordGameWindow : BaseWindow {
        public List<RectTransform> SpawnPoints;
        public RectTransform Parent;
        public RectTransform RemovePoint;
        
        private LetterGeneratorService _letterGeneratorService;
        private PasswordMiniGameConfig _config;

        private char _currentCharacter;
        private int _index;

        private float _spawnTime;

        private List<LetterView> _views;

        private string _passwordCopy;

        private bool _needMain;
        private List<LetterView> _viewsToDelete;

        [Inject]
        private void Construct(LetterGeneratorService letterGeneratorService,
                               PasswordMiniGameConfig config) {
            _letterGeneratorService = letterGeneratorService;
            _config = config;
        }

        public override void Initialize(string id) {
            
        }

        private void Awake() {
            _views = new List<LetterView>();
            _viewsToDelete = new List<LetterView>();

            _passwordCopy = string.Copy(_config.Password);
            var character = _passwordCopy[_index];
            SpawnLetter(character.ToString(), true);
        }

        private void SpawnLetter(string character, bool main = false) {
            var letterView = _letterGeneratorService.Get(Parent);

            var randomIndex = Random.Range(0, SpawnPoints.Count);

            letterView.SetText(character);
            letterView.SetMainVisibility(main);
            var randomPoint = SpawnPoints[randomIndex];

            letterView.transform.position = randomPoint.position;
            letterView.Main = main;
            _views.Add(letterView);
        }

        private void Update() {
            _spawnTime += Time.deltaTime;

            CheckCurrentInput();
            
            MoveLetters();

            CheckLetterPosition();
            CheckLetterInput();
            
            if (_spawnTime < _config.SpawnDelta) return;

            CheckNeedMain();
            _spawnTime = 0f;

            var randomIndex = Random.Range(0, _config.OtherCharacters.Length);
            var randomLetter = _config.OtherCharacters[randomIndex];
            
            SpawnLetter(randomLetter, _needMain);
        }

        private void CheckNeedMain() {
            bool hasMain = false;
            foreach (var view in _views) {
                if (view.Main) {
                    hasMain = true;
                }
            }

            _needMain = !hasMain;
        }

        private void CheckCurrentInput() {
            //var status = Input.GetKeyDown("N");
            
            //Debug.Log(status);
        }

        private void CheckLetterPosition() {
            foreach (var view in _views) {
                var rectTransform = (RectTransform)view.transform;

                if (rectTransform.position.y <= RemovePoint.position.y) {
                    _viewsToDelete.Add(view);
                }
            }

            foreach (var view in _viewsToDelete) {
                _views.Remove(view);
                
                _letterGeneratorService.Release(view.gameObject);
            }
            
            _viewsToDelete.Clear();
        }

        private void CheckLetterInput() {
        }

        private void MoveLetters() {
            foreach (var view in _views) {
                var rectTransform = (RectTransform)view.transform;

                var moveVector = new Vector3(0f, -Time.deltaTime * _config.LetterSpeed, 0f);
                rectTransform.localPosition += moveVector;
            }
        }
    }
}