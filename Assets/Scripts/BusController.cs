using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusController : CarController
{
    public Vector3 spawnPoint, spawnRotation;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        transform.localPosition = spawnPoint;
        transform.eulerAngles = spawnRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
