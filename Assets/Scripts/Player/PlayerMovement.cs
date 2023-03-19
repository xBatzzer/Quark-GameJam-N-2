using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] CharacterController chController;
    [SerializeField] float speed = 10f;
    [SerializeField] Transform groundCheck;
    [SerializeField] float sphereRadius = 0.3f;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float jumpHeight = 3f;
    [SerializeField] float gravity = -9.8f;
    [SerializeField] GameObject maxLeft;
    [SerializeField] GameObject maxRight;

    private Vector3 velocity; 
    private bool isGrounded;

    private bool canMoveRight;
    private bool canMoveLeft;

    void Start()
    {
        
    }

    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadius, groundMask);

        if (isGrounded && velocity.y<0) 
        {
            velocity.y = -2f;
        }

        float z = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        float zInput = transform.position.z;
        float maxRightZ = maxRight.transform.position.z;
        float maxLeftZ = maxLeft.transform.position.z;

        Vector3 move = transform.forward * z;

        chController.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        chController.Move(velocity * Time.deltaTime);

    }
}
