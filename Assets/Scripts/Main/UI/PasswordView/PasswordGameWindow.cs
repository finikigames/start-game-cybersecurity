using System;
using System.Collections.Generic;
using Global.Flow.Condition;
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
        private FlowConditionService _conditionService;

        private char _currentCharacter;
        private int _index;

        private float _spawnTime;

        private List<LetterView> _views;

        private string _passwordCopy;

        private bool _needMain;
        private List<LetterView> _viewsToDelete;

        private bool _pressed;

        private LetterView _mainView;
        private PasswordGameCondition _condition;

        [Inject]
        private void Construct(LetterGeneratorService letterGeneratorService,
                               PasswordMiniGameConfig config,
                               FlowConditionService conditionService) {
            _letterGeneratorService = letterGeneratorService;
            _config = config;
            _conditionService = conditionService;
        }

        public override void Initialize(string id) {
            
        }

        private void Awake() {
            _condition = new PasswordGameCondition();
            _conditionService.RegisterCondition("password_minigame_win", _condition);
            
            _views = new List<LetterView>();
            _viewsToDelete = new List<LetterView>();

            _passwordCopy = string.Copy(_config.Password);
            var character = _passwordCopy[_index];
            SpawnLetter(character.ToString(), true);
        }

        private void SpawnLetter(string character, bool main = false) {
            var letterView = _letterGeneratorService.Get(Parent);

            if (main) {
                _mainView = letterView;
            }
            
            var randomIndex = Random.Range(0, SpawnPoints.Count);

            letterView.SetMainVisibility(main);
            letterView.SetText(character);
            var randomPoint = SpawnPoints[randomIndex];

            letterView.transform.position = randomPoint.position;
            _views.Add(letterView);
        }

        private void Update() {
            _spawnTime += Time.deltaTime;

            if (_index >= _passwordCopy.Length) {
                _condition.Ready = true;
                return;
            }
            MoveLetters();

            CheckLetterPosition();
            CheckLetterInput();

            if (_pressed) {
                _needMain = true;

                _views.Remove(_mainView);
                
                _letterGeneratorService.Release(_mainView.gameObject);
                _index++;
                _pressed = false;
                _mainView = null;
            }
            
            if (_spawnTime < _config.SpawnDelta) return;

            CheckNeedMain();
            _spawnTime = 0f;

            string letter;
            if (!_needMain) {
                var randomIndex = Random.Range(0, _config.OtherCharacters.Length);
                letter = _config.OtherCharacters[randomIndex];
            }
            else {
                letter = _passwordCopy[_index].ToString();
            }

            SpawnLetter(letter, _needMain);
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
            var currentCharacter = _passwordCopy[_index];

            var upper = currentCharacter.ToString().ToUpper();

            var keyCode = Enum.Parse<KeyCode>(upper);
            _pressed = Input.GetKeyDown(keyCode);
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