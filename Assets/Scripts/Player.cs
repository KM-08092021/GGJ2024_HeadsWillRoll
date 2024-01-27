using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 spawnPoint, spawnRotation;
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = spawnPoint;
        transform.eulerAngles = spawnRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
