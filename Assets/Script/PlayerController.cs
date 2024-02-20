using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;
    public float rotationSpeed = 700.0f;
    private CharacterController controller;

    private Transform cameraTransform;

    public bool canMove = true;
    private bool requiredKeyRelease;
    

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        cameraTransform = Camera.main.transform;
        CameraSwitcher.OnCamerSwitched += HandleCameraSwitch;
    }

    private void HandleCameraSwitch(GameObject newCamera)
    {
        cameraTransform = newCamera.transform;
        ToggleMovement(false);
        requiredKeyRelease = true;
    }

    public void ToggleMovement(bool enable)
    {
        canMove = enable;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if(requiredKeyRelease)
        {
            if(Mathf.Approximately(horizontalInput, 0) && Mathf.Approximately(verticalInput, 0))
            {
                requiredKeyRelease = false;
                ToggleMovement(true);
            }
        }
        if (canMove)
        {

            Vector3 direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

            direction = cameraTransform.TransformDirection(direction);
            direction.y = 0;

            if (direction.magnitude >= 0.1f)
            {
                controller.Move(direction * speed * Time.deltaTime);
            }
        }
    }
}
