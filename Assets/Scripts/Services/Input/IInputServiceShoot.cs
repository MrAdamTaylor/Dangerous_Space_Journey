using UnityEngine;

namespace Services.Input
{
    public interface IInputServiceShoot
    {
        void ProcessShootingBullet(GameObject[] bullets);

        void ProcessLaserShoot(GameObject laser);
    }
}