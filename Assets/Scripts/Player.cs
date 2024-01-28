using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 spawnPoint, spawnRotation;
    public ThirdPersonCameraRigController camController;
    public Camera thirdPersonCamera, firstPersonCamera;
    public List<Rigidbody> playerParts = new List<Rigidbody>();
    public Transform headTransform;
    // Start is called before the first frame update
    void Start()
    {
        _addEventListeners();
        transform.localPosition = spawnPoint;
        transform.eulerAngles = spawnRotation;
    }

    void _addEventListeners()
    {
        EventManifest.eventGameFinish += PlayerFinish;
    }

    void _removeEventListeners()
    {
        EventManifest.eventGameFinish -= PlayerFinish;
    }


    public void ActivateFirstPerson()
    {
        thirdPersonCamera.enabled = false;
        firstPersonCamera.enabled = true;
    }

    public void ActivateThirdPerson()
    {
        thirdPersonCamera.enabled = true;
        firstPersonCamera.enabled = false;
    }

    public void ToggleKinematic(bool toggle)
    {
        foreach(Rigidbody rb in playerParts) 
        {
            rb.isKinematic = toggle;
        }
    }

    public void PlayerFinish()
    {
        camController.disableInput = true;
    }
}
