using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverpassController : MonoBehaviour
{
    public GameObject bus, player;
    public void StartIntro()
    {
        StartCoroutine(StartIntro_IE());
    }

    IEnumerator StartIntro_IE()
    {
        Instantiate(bus, transform);
        Instantiate(player, transform);
        player.GetComponent<ThirdPersonCameraRigController>().disableInput = true;
        yield return new WaitForSeconds(3.0f);
    }
}
