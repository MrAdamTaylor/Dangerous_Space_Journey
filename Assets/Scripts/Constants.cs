using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    #region Константы для ограничения движения
        public const float PositiveEpsilonRange = 0.001f;
        public const float NegativeEpsilonRange = -0.001f;
    #endregion

    #region Константы для границ карты

        public const float LeftBorder = -100f;
        public const float RightBorder = 100f;
        public const float TopBorder = 60f;
        public const float BottomBorder = -60f;
    
    #endregion

}
