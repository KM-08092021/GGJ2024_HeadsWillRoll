using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Game;

public class CutsceneManager : MonoBehaviour
{
    //public Level level1;
    public OverpassController overPassCutsceneController;

    private void Awake()
    {
        _addEventListeners();
    }

    void _addEventListeners()
    {
        EventManifest.eventGameStart += StartIntro;
    }

    private void OnDestroy()
    {
        _removeEventListeners();
    }

    void _removeEventListeners()
    {
        EventManifest.eventGameStart -= StartIntro;
    }

    void StartIntro()
    {
        overPassCutsceneController.StartIntro(() =>
        {
            gameInstance.changeGameState(GameState.LEVEL1);
        });
    }


}
