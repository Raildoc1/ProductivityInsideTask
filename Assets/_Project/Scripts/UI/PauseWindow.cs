using UnityEngine;
using UnityEngine.UI;

namespace PITask.UI
{
    public class PauseWindow : Window
    {
        [SerializeField] private Button _closeButton;

        private void OnEnable()
        {
            _closeButton.onClick.AddListener(Hide);
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(Hide);
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
    }
}