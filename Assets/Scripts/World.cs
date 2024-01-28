using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public static Game game;
    public static Game.GameState beginningState = Game.GameState.LEVEL1;
    // Start is called before the first frame update
    void Start()
    {
        game = new Game();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
