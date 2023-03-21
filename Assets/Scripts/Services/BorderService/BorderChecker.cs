using UnityEngine;

namespace Services.BorderService
{
    class BorderChecker : IBorderChecker
    {
        public void BorderCheck(ref Vector3 vec)
        {
            if (vec.z > Constants.TopBorder)
            {
                vec.z = Constants.BottomBorder;
            }

            if (vec.z < Constants.BottomBorder)
            {
                vec.z = Constants.TopBorder;
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