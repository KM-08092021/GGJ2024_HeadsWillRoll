using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManifest
{
    public static event Action eventGameStart;
    public static event Action eventLevel1Start;
    public static event Action eventGameWin;
    public static event Action eventGameLose;
    public static event Action eventGameFinish;
    public static event Action<bool> eventIsTouchingItem;
    public static event Action eventLevel1PlayerLoaded;

    public static void dispatchGameStart()
    {
        Debug.Log("Dispatching game start");
        if (eventGameStart == null)
            return;
        eventGameStart();
    }

    public static void dispatchLevel1Start()
    {
        Debug.Log("Dispatching level 1 start");
        if (eventLevel1Start == null)
            return;
        eventLevel1Start();
    }

    public static void dispatchGameWin()
    {
        Debug.Log("Dispatching game win condition");
        if (eventGameWin == null)
            return;
        eventGameWin();
    }

    public static void dispatchGameLose() 
    {
        Debug.Log("Dispatching game lose condition");
        if (eventGameLose == null)
            return;
        eventGameLose();
    }

    public static void dispatchGameFinish()
    {
        Debug.Log("Dispatching game finish");
        if (eventGameFinish == null)
            return;
        eventGameFinish();
    }

    public static void dispatchPlayer1Load()
    {
        Debug.Log("Dispatching game finish");
        if (eventLevel1PlayerLoaded == null)
            return;
        eventLevel1PlayerLoaded();
    }

    public static void dispatchIsTouchingItem(bool isTouchingItem)
    {
        Debug.Log("Dispatching item touching: " + isTouchingItem);
        if (eventGameFinish == null)
            return;
        eventIsTouchingItem(isTouchingItem);
    }
}
