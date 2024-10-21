using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public float speed = 5f;

    public float sensitivity = 2f;


    public Camera playerCamera;

    private float horizontalInput;
    private float verticalInput;

    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement = transform.TransformDirection(movement);
        movement *= speed * Time.deltaTime;
        transform.position += movement;


        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(new Vector3(0, mouseX, 0));


        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        playerCamera.transform.Rotate(new Vector3(-mouseY, 0, 0));
    }
}
