using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public OverpassController overPass;

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
        overPass.StartIntro();
    }
}
