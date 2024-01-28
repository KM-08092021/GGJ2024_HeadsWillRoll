using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverpassController : MonoBehaviour
{
    public GameObject bus, player;
    Player _player;
    public float kinematicDisableDelay;

    public void StartIntro(Action callback)
    {
        StartCoroutine(StartIntro_IE(() => callback()));
    }

    IEnumerator StartIntro_IE(Action callback)
    {
        Instantiate(bus, transform);
        _player = Instantiate(player, transform).GetComponent<Player>();
        _player.camController.disableInput = true;
        _player.ActivateFirstPerson();
        _player.ToggleKinematic(true);
        yield return new WaitForSeconds(kinematicDisableDelay);
        _player.ToggleKinematic(false);
        yield return new WaitForSeconds(5f);
        Destroy(_player.gameObject);
        callback();
    }
}
