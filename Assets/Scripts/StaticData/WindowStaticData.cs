using System.Collections.Generic;
using UnityEngine;

namespace UI.Services.Factory
{
    [CreateAssetMenu(menuName = "Static Data/Window static data", fileName = "WindowStaticData")]   
    public class WindowStaticData : ScriptableObject
    {
        public List<WindowConfig> Configs;
    }
}