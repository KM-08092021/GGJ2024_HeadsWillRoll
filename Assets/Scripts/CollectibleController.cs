using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    public string ID;
    public Level level;

    private void Start()
    {
        //level = GameObject.Find("Level1").GetComponent<Level>();
    }
    void OnCollisionEnter(Collision other)
    {
        //level.EnablePickup();
        //Debug.Log("Collision detected: " + other.gameObject.name);

        //if (other.gameObject.tag == "Player" && !level.isPickupDisabled)
        //{
        //    Destroy(GetComponent<Rigidbody>());
        //    level.CollectItem(gameObject);
        //    transform.parent = level.GetPlayerTransform();
        //}
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Part")
            EventManifest.dispatchIsTouchingItem(true);
    }

    void OnTriggerStay(Collider other)
    {
        //Debug.Log("Inside trigger zone with: " + other.gameObject.name);
        if ((other.gameObject.tag == "Player" || other.gameObject.tag == "Part") && level.isPickupEnabled)
        {
            Destroy(GetComponent<Rigidbody>());
            level.CollectItem(gameObject);
            transform.parent = level.GetPlayerTransform();
            GetComponent<Collider>().isTrigger = false;
            EventManifest.dispatchIsTouchingItem(false);
        }
    }

    private void OnCollisionStay(Collision other)
    {
        //if (other.gameObject.tag == "Player" && level.isPickupEnabled)
        //{
        //    Destroy(GetComponent<Rigidbody>());
        //    level.CollectItem(gameObject);
        //    transform.parent = level.GetPlayerTransform();
        //}
    }

    void OnTriggerExit(Collider other)
    {
        EventManifest.dispatchIsTouchingItem(false);
    }

}
