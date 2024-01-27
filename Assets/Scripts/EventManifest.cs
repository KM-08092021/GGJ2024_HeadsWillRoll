using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManifest
{
    public static event Action eventGameStart;

    public static void dispatchGameStart()
    {
        Debug.Log("Dispatching game start");
        if (eventGameStart == null)
            return;
        eventGameStart();
    }


}
