using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game
{
    public static Game gameInstance;
    static GameState currentGameState;
    public enum GameState { START, LEVEL1, WIN, LOSE, FINISH }    
    public Game()
    {
        gameInstance = this;

        //currentGameState = GameState.START;
        currentGameState = GameState.LEVEL1;
        _setState(currentGameState);
    }

    protected virtual void _setState(GameState state)
    {
        currentGameState = state;
        switch (currentGameState) 
        {
            case GameState.START:
                EventManifest.dispatchGameStart();
                break;
            case GameState.LEVEL1:
                EventManifest.dispatchLevel1Start();
                break;
            case GameState.WIN:
                EventManifest.dispatchGameWin();
                break;
            case GameState.LOSE:
                EventManifest.dispatchGameLose();
                break;
            case GameState.FINISH:
                EventManifest.dispatchGameFinish();
                break;
        }
    }

    public void changeGameState(GameState state)
    {
        _setState(state);
    }

}
