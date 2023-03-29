using UnityEngine;

namespace Services.BorderService
{
    class BorderChecker : IBorderChecker
    {
        public void BorderCheck(ref Vector3 vec)
        {
            if (vec.y > Constants.TopBorder)
            {
                vec.y = Constants.BottomBorder;
            }

            if (vec.y < Constants.BottomBorder)
            {
                vec.y = Constants.TopBorder;
            }

            if (vec.x > Constants.RightBorder)
            {
                vec.x = Constants.LeftBorder;
            }

            if (vec.x < Constants.LeftBorder)
            {
                vec.x = Constants.RightBorder;
            }

        }
    }
}