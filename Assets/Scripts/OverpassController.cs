using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverpassController : MonoBehaviour
{
    public GameObject bus, player, playerParts;
    Player _player;

    public void StartIntro()
    {
        StartCoroutine(StartIntro_IE());
    }

    IEnumerator StartIntro_IE()
    {
        Instantiate(bus, transform);
        _player = Instantiate(player, transform).GetComponent<Player>();
        _player.camController.disableInput = true;
        _player.ActivateFirstPerson();
        _player.ToggleKinematic(true);
        yield return new WaitForSeconds(4.5f);
        _player.ToggleKinematic(false);
        
    }
}
