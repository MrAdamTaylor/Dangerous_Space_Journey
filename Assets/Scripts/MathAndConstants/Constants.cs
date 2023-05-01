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

    #region Константы коэффициенты для игрока

        public const float COEF_PLAYER_MOVE = 1000f;
        public const float COEF_TURN_MOVE = 500f;

    #endregion

    #region Константы для взрыва

        public const float COEF_EXPLOSION_POWER = 10f;
        
    #endregion
    
    #region Константы для Quaternion

        public const float YVALUE = 0; //90
        public const float ZVALUE = 0; //270

        public const float NEGATIVEYVALUE = 180; //270
        public const float NEGATIVEZVALUE = 180; //90


        public const float MAXANGLEVALUE = 360;

    #endregion

    #region Константы для времени жизни GIZMOS

        public const float MIDDLE_LIFE_TIME = 5f;
        public const float SHORT_LIFE_TIME = 1f;


    #endregion

}
