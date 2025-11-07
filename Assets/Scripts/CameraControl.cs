using UnityEngine;
using System;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    float mouseSenistivity = 100f;
    Transform playerBody;
    float xRotation = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRotation();
    }

    void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSenistivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSenistivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Math.Clamp(xRotation, -90f, 88f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(eulers: Vector3.up * mouseX);

    }
}
