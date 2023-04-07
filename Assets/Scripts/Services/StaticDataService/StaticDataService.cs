using System.Collections.Generic;
using System.Linq;
using UI.Services.Factory;
using UI.Services.Windows;
using UnityEngine;

namespace Services.StaticDataService
{
    class StaticDataService : IStaticDataService
    {
        private Dictionary<WindowID, WindowConfig> _windowConfigs;
        private const string StaticDataWindowsPath = "";

        /*public WindowConfig ForWindow(WindowID windowID)
        {
            _windowConfigs = Resources.Load<WindowStaticData>(StaticDataWindowsPath)
                .Configs
                .ToDictionary(x => x.windowId, x => x);
            
            //TODO доделать позже
            return WindowConfig;
        }*/
    }
}