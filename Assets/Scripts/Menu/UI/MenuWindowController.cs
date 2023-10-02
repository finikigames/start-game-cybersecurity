using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu.UI {
    public class MenuWindowController : MonoBehaviour {
        [SerializeField] private Button _playButton;

        [SerializeField] private Sprite _hoverSprite;
        [SerializeField] private Sprite _defaultSprite;

        [SerializeField] private float _scaleTime;
        [SerializeField] private float _scaleSpeed;
        [SerializeField] private GameObject _scaleObject;

        [SerializeField] private float _loadingTime;
        [SerializeField] private CanvasGroup _group;

        public void OnHoverEnter() {
            _playButton.image.sprite = _hoverSprite;
        }

        public void OnHoverExit() {
            _playButton.image.sprite = _defaultSprite;
        }
        
        private void Start() {
            _playButton.onClick.RemoveAllListeners();
            _playButton.onClick.AddListener(() => StartCoroutine(LoadMainScene()));
        }

        private IEnumerator LoadMainScene() {
            float time = 0f;
            while (time < _scaleTime) {
                time += Time.deltaTime;
                
                _scaleObject.transform.localScale += Vector3.one * Time.deltaTime * _scaleSpeed;
                
                yield return null;
            }

            time = 0f;

            while (time < _loadingTime) {
                time += Time.deltaTime;

                _group.alpha = Mathf.Lerp(0, 1, time);
            }

            yield return new WaitForSeconds(2f);

            var currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene("Main");
            
            /*time = 0f;

            while (time < _loadingTime) {
                time += Time.deltaTime;

                _group.alpha = Mathf.Lerp(1, 0, time);
            }

            var task = SceneManager.UnloadSceneAsync(currentScene);

            yield return task;&*/
        }
    }
}