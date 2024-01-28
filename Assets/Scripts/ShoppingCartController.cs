using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShoppingCartController : MonoBehaviour
{
    public Level level;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Entered trigger zone with: " + other.gameObject.name);
        if(other.tag == "Part")
        {
            level.RedeemItem(other.gameObject);
            Destroy(other.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("Inside trigger zone with: " + other.gameObject.name);
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("Exited trigger zone with: " + other.gameObject.name);
    }
}
