using System.Collections;
using UnityEngine;

namespace SpaceShipBus
{
    public class GameExecuter : MonoBehaviour
    {
        private void Update()
        {
            GlobalBus.Sync.Publish(this, new GameControllerHandler());
        }

        //TODO это ещё сделаю :)
        IEnumerator GameHandlerLauncher()
        {
            yield return new WaitForSeconds(0.05f);

        }


    }
}
