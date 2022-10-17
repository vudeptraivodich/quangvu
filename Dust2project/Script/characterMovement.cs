using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3f;
    public LayerMask layerMask;
    private CharacterController characterController;
    public float characterHeight = 6f;
    public Transform groundCheck;

    public float senX = 200f;
    public float senY = 200f;
    float xRot;
    float yRot;


    Vector3 velocity;
    bool isGrounded;

    private void Start()
    {
        characterController = gameObject.AddComponent<CharacterController>(); //add component characterController when game start
        Cursor.lockState = CursorLockMode.Locked; // lock mouse
        Cursor.visible = false;
        characterController.height = characterHeight;
    }

    private void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senY;
        yRot += mouseX;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f); //limited xRot 90

        Camera.main.transform.rotation = Quaternion.Euler(xRot, yRot, 0); //from google
        transform.rotation = Quaternion.Euler(0, yRot, 0); //setup transform 

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, layerMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal"); //keycontrol A,D
        float z = Input.GetAxis("Vertical"); //keycontrol W,S
        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime); //move character

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //calculate jumping force
        }

        velocity.y += gravity * Time.deltaTime; //plus gravity
        characterController.Move(velocity * Time.deltaTime);
    }
}
