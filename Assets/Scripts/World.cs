using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public static Game game;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartDelay()
    {
        //yield return new WaitForSeconds(2f);
        game = new Game();
        yield return null;
    }
}
