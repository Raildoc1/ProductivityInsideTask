using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PITask.UI
{
    public enum WindowType
    {
        Pause,
        End,
    }

    public class WindowsManager : MonoBehaviour
    {
        private Dictionary<WindowType, Window> _windows = new Dictionary<WindowType, Window>() { };
        public bool HasWindows => _windows.Any(x => x.Value.Shown);

        public void RegisterWindow(WindowType type, Window window)
        {
            if(_windows.ContainsKey(type))
            {
                throw new System.Exception($"Window {type} is already exists!");
            }

            _windows[type] = window;
        }

        public void TryShowWindow(WindowType type)
        {
            if (!_windows.ContainsKey(type))
            {
                throw new System.Exception($"No window of type {type} found!");
            }

            if(HasWindows)
            {
                return;
            }

            _windows[type].Show();
        }
    }

    public abstract class Window : MonoBehaviour
    {
        [SerializeField] private WindowsManager _manager;
        [SerializeField] private WindowType _type;

        private bool _shown = false;

        public bool Shown => _shown;

        protected virtual void Awake()
        {
            _manager.RegisterWindow(_type, this);
            Hide();
        }

        public virtual void Show() => _shown = true;
        public virtual void Hide() => _shown = false;
    }
}