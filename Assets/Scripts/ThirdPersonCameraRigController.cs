using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThirdPersonCameraRigController : MonoBehaviour
{
    public Transform playerTransform, cameraTransform;
    Rigidbody playerRigidbody;
    public float lerpSpeed, offsetMagnitude;

    public float yLowClampAngle = -30.0f;
    public float yClampRange = 60.0f;
    public float mouseSensitivity = 50.0f;
    public float smoothing = 3.0f;

    //public GameObject player;
    private Vector2 _smoothMouse;
    private bool isCursorVisible = false;
    private Vector2 _mouseAbsolute;

    public bool limitDiagonalSpeed = true;

    public float torqueMultiplier = 1f, dampingModifier = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        if (playerTransform == null)
        {
            Debug.LogError("playerTransform is not assigned.");
            return;
        }
        playerRigidbody = playerTransform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.Lerp(transform.position, playerTransform.position, lerpSpeed * Time.deltaTime);

        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        mouseDelta = Vector2.Scale(mouseDelta, new Vector2(mouseSensitivity, mouseSensitivity));

        _smoothMouse.x = Mathf.Lerp(_smoothMouse.x, mouseDelta.x, 1f / smoothing);
        _smoothMouse.y = Mathf.Lerp(_smoothMouse.y, mouseDelta.y, 1f / smoothing);

        _mouseAbsolute += _smoothMouse;

        _mouseAbsolute.y = Mathf.Clamp(_mouseAbsolute.y, yLowClampAngle, yLowClampAngle + yClampRange);


        transform.localRotation = Quaternion.AngleAxis(_mouseAbsolute.x, Vector3.up);
    }

    private void FixedUpdate()
    {
        if (!isCursorVisible)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            //Screen.lockCursor = true;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //Screen.lockCursor = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isCursorVisible = !isCursorVisible;
        }

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        float inputModifyFactor = (inputX != 0.0f && inputY != 0.0f && limitDiagonalSpeed) ? 0.6701f : 1.0f;

        Vector3 horizontalInputLocalNormalized = new Vector3(0f, 0f, 1);

        Debug.Log("local rot: " + transform.rotation.eulerAngles);
        Debug.Log("force vector: " + transform.rotation * new Vector3(0,0,1));

        Vector3 horizontalInput = transform.rotation * new Vector3(0f, 0f, inputX) * torqueMultiplier * -1;
        playerRigidbody.AddTorque(horizontalInput);
        Vector3 verticalInput = transform.rotation * new Vector3(inputY, 0f, 0f) * torqueMultiplier;
        playerRigidbody.AddTorque(verticalInput);


        Vector3 currentVelocity = playerRigidbody.velocity;
        playerRigidbody.AddForce(currentVelocity * -1 * dampingModifier);

        

    }

    Vector3 TransformVectorLocalToWorld(Transform source, Vector3 sourceVector)
    {
        // Get the local-to-world matrix of the source transform
        Matrix4x4 localToWorldMatrix = source.localToWorldMatrix;

        // Transform the vector from local space to world space using the localToWorldMatrix
        Vector4 worldSpaceVector = localToWorldMatrix * new Vector4(sourceVector.x, sourceVector.y, sourceVector.z, 1f);

        return new Vector3(worldSpaceVector.x, worldSpaceVector.y, worldSpaceVector.z);
    }
}
