using System;
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

        public event Action<WindowType> WindowShown;
        public event Action<WindowType> WindowHidden;

        public void RegisterWindow(WindowType type, Window window)
        {
            if (_windows.ContainsKey(type))
            {
                throw new System.Exception($"Window {type} is already exists!");
            }

            window.WindowShown += FireWindowShown;
            window.WindowHidden += FireWindowHidden;
            _windows[type] = window;
        }

        public void TryShowWindow(WindowType type)
        {
            if (!_windows.ContainsKey(type))
            {
                throw new System.Exception($"No window of type {type} found!");
            }

            if (HasWindows)
            {
                return;
            }

            _windows[type].Show();
        }

        private void FireWindowShown(WindowType type)
        {
            WindowShown?.Invoke(type);
        }

        private void FireWindowHidden(WindowType type)
        {
            WindowHidden?.Invoke(type);
        }
    }

    public abstract class Window : MonoBehaviour
    {
        [SerializeField] private WindowsManager _manager;
        [SerializeField] private WindowType _type;

        private bool _shown = false;

        public event Action<WindowType> WindowShown;
        public event Action<WindowType> WindowHidden;

        public bool Shown => _shown;

        protected virtual void Awake()
        {
            _manager.RegisterWindow(_type, this);
            Hide();
        }

        public virtual void Show()
        {
            WindowShown?.Invoke(_type);
            _shown = true;
        }

        public virtual void Hide()
        {
            WindowHidden?.Invoke(_type);
            _shown = false;
        }
    }
}