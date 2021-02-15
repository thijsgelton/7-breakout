using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Group_7.Breakout.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private int _brickCount, _lifeCount, _score;
        private bool _isGameOver;

        [SerializeField] private Transform bricks;
        [SerializeField] private Toggle[] lives;
        [SerializeField] private RectTransform loseScreen, winScreen;
        [SerializeField] private TextMeshProUGUI score;
        [SerializeField] private float time;


        public void CollideBrick(Collision other)
        {
            if (_isGameOver) return;
            _brickCount--;
            other.gameObject.SetActive(false);
            score.text = $"Score: {++_score}";
            if (_brickCount > 0) return;
            _isGameOver = true;
            winScreen.gameObject.SetActive(true);
            Invoke(nameof(Restart), time);
        }

        public void CollideWater(Collision other)
        {
            if (_isGameOver) return;
            _lifeCount--;
            lives[_lifeCount].isOn = false;
            score.text = $"Score:{--_score}";
            if (_lifeCount != 0) return;
            _isGameOver = true;
            loseScreen.gameObject.SetActive(true);
            Invoke(nameof(Restart), 2);
        }

        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    
        private void Reset()
        {
            bricks = null;
            lives = null;
            loseScreen = null;
            score = null;
            winScreen = null;
            _isGameOver = false;
            time = 5;
        }
        // Start is called before the first frame update
        void Start()
        {
            _brickCount = bricks.childCount;
            _isGameOver = false;
            _lifeCount = lives.Length;
            Time.timeScale = 1;
        }

        // Update is called once per frame
        void Update()
        {
            if (_isGameOver) return;
            if (Input.GetKey("escape"))
            {
                Time.timeScale = 0;
            }
            
            if (Input.GetKey("return"))
            {
                Time.timeScale = 1;
            }
            
            if (Input.GetKey("r"))
            {
                Restart();
            }
            
        }
    }
}
