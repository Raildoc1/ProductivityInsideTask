using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace PITask.UI
{
    public class EndWindow : Window
    {
        [SerializeField] private Button _restartButton;

        private void OnEnable()
        {
            _restartButton.onClick.AddListener(Restart);
        }

        private void OnDisable()
        {
            _restartButton.onClick.RemoveListener(Restart);
        }

        public override void Hide()
        {
            base.Hide();
            Time.timeScale = 1.0f;
            gameObject.SetActive(false);
        }

        public override void Show()
        {
            base.Show();
            gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        private void Restart()
        {
            Hide();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}