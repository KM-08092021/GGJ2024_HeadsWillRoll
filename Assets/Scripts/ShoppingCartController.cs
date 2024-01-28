using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShoppingCartController : MonoBehaviour
{
    public Level level;
    public ParticleSystem collectionEffect;


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
            PlayParticleSystemOnce();
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

    void PlayParticleSystemOnce()
    {
        // Play the ParticleSystem
        collectionEffect.Play();

        // Wait for the duration of the ParticleSystem's main duration
        float duration = collectionEffect.main.duration;
        StartCoroutine(StopParticleSystemAfterDelay(duration));
    }

    System.Collections.IEnumerator StopParticleSystemAfterDelay(float delay)
    {
        // Wait for the specified duration
        yield return new WaitForSeconds(delay);

        // Stop the ParticleSystem
        collectionEffect.Stop();
    }
}
