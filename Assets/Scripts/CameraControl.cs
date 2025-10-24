using UnityEngine;

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

    }
}
