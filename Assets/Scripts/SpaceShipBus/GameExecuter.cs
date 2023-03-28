using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
