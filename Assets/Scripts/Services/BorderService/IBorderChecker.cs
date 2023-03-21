using UnityEngine;

namespace Services.BorderService
{
    public interface IBorderChecker 
    {
        public void BorderCheck(ref Vector3 vec);

    }
}