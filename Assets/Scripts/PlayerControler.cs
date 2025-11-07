using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerComtroler : MonoBehaviour
{
    [SerializeField]
    float speed = 12;
    Vector3 velocity;

    CharacterController characterController;

    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundMask;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        RaycastHit hit;
        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down),
        out hit, 0.4f, groundMask))
        {
            string terrainType = hit.collider.gameObject.tag;

            switch (terrainType) 
            {
                default: speed = 12; break;
                case "Slow": speed = 6; break;
                case "Fast": speed= 24; break;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = x * transform.right + z * transform.forward;
        characterController.Move(move * speed * Time.deltaTime);
    }
}
