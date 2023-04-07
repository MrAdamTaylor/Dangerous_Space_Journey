using System;
using UI.Services.Windows;
using UI.Windows;

namespace UI.Services.Factory
{
    [Serializable]
    public class WindowConfig
    {
        public WindowID windowId;
        public WindowBase prefab;
    }
}