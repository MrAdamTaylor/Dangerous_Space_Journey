using UnityEngine;

namespace Services.Input
{
    abstract class InputServiceShoot : IInputServiceShoot
    {
        public abstract void ProcessShootingBullet(GameObject[] bullets);

        public abstract void ProcessLaserShoot(GameObject laser);

    }
}