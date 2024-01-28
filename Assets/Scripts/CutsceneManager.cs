using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Game;

public class CutsceneManager : MonoBehaviour
{
    //public Level level1;
    public OverpassController overPassCutsceneController;
    public GameObject level1Prefab;
    public Transform level1Spawn;

    private void Awake()
    {
        _addEventListeners();
    }

    void _addEventListeners()
    {
        EventManifest.eventGameStart += StartIntro;
        EventManifest.eventLevel1Start += StartLevel1;
    }

    private void OnDestroy()
    {
        _removeEventListeners();
    }

    void _removeEventListeners()
    {
        EventManifest.eventGameStart -= StartIntro;
        EventManifest.eventLevel1Start -= StartLevel1;
    }

    void StartIntro()
    {
        overPassCutsceneController.StartIntro(() =>
        {
            
            gameInstance.changeGameState(GameState.LEVEL1);
        });
    }

    void StartLevel1()
    {
        Instantiate(level1Prefab, level1Spawn);
    }




}
