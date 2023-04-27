using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    #region Константы для ограничения движения
        public const float PositiveEpsilonRange = 0.001f;
        public const float NegativeEpsilonRange = -0.001f;

        //Граница для угла
        public const float AngleEpsilon = 1f;
    #endregion

    #region Константы для границ карты

        public const float LeftBorder = -100f;
        public const float RightBorder = 100f;
        public const float TopBorder = 60f;
        public const float BottomBorder = -60f;
    
    #endregion


    #region Константы для Quaternion

        public const float YVALUE = 270;
        public const float ZVALUE = 90;

        public const float NEGATIVEYVALUE = 90;
        public const float NEGATIVEZVALUE = 270;


        public const float MAXANGLEVALUE = 360;

        #endregion

}
