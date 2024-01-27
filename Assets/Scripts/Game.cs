using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    static Game gameInstance;
    static GameState currentGameState;
    public enum GameState { START, LEVEL1, FINISH }    
    public Game()
    {
        gameInstance = this;

        currentGameState = GameState.START;
        _setState(currentGameState);
    }

    protected virtual void _setState(GameState state)
    {
        switch(state) 
        {
            case GameState.START:
                EventManifest.dispatchGameStart();
                break;
        }
    }

}
