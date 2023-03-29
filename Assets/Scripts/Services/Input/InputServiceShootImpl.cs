using UnityEngine;

namespace Services.Input
{
    class InputServiceShootImpl : InputServiceShoot
    {
        public override void ProcessShootingBullet(GameObject[] bullets)
        {
            if (UnityEngine.Input.GetButton("Fire1"))
            {
                ActiveLaser(bullets);
            }
            else
            {
                DeactiveLaser(bullets);
            }
        }

        private void DeactiveLaser(GameObject[] bullets)
        {
            foreach (GameObject bullet in bullets)
            {
                bullet.SetActive(false);
            }
        }

        private void ActiveLaser(GameObject[] bullets)
        {
            foreach (GameObject bullet in bullets)
            {
                bullet.SetActive(true);
            }
        }

        public override void ProcessLaserShoot(GameObject laser)
        {
            throw new System.NotImplementedException();
        }
    }
}