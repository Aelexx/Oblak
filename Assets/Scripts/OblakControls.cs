/*
1. DO all stance in func print work;
2. DO Inspector when into water in middle point untick, and Prone on bottom lake also needs to be bottomlake;
3. 

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static Orkis;
using UnityEngine.Rendering;
using static BallScript;
public class OblakControls : MonoBehaviour
{
    [Header("Player settings")]
    public CharacterController controller;
    public Vector3 playerVelocity;
    public Animator anime;
    public Button myButton;
    //public Vector3 playerVelocityJump;
    
    public Vector3 rotate;
    public float zAngle, yAngle, xAngle;
    public float playerSpeed = 2.0f;
    public float playerSprintSpeed = 5.0f;
    
    private bool isGrounded;
    public bool isStand;
    public bool isWalk;
    public bool isSprint;
    public bool isProne;
    public bool isJump;
    public bool isFly;

    public bool isFlyMoving;
    public bool isFlyTurbo;
    public bool isWater;
    public bool isBottom;
    
    public float playerFlying;
    //public float flyingHeight = 2f;

    //public Transform from, to;
    public float timeCount = 0;
    // public float horizontalRotateSpeed = 2.1f;
    // public float verticalRotateSpeed = 2.1f;

    public float playerJumpHeight = 3.0f;
    private float gravityPlayer = -2.0f;
    public float speedFalling;
    
    public float lifeTimeObject = 2.0f;
    public GameObject Player, Cube1;

    private string hitObject;

    public int total_scr, score, score2;


    public void Awake()
    {
        Player = GameObject.FindWithTag("Player");
        print("Welcome!");

                
    }

    // Start is called before the first frame update
    public void Start()
    {   

        controller = gameObject.AddComponent<CharacterController>();
        controller.radius = 0.55f;

        isStand = true;
        isGrounded = true;
        isProne = false;
        isWalk = false;
        isJump = false;
        isSprint = false;
        isFly = false;
        isWater = false;
        isBottom = false;
        total_scr = 0;
    }
    // Update is called once per frame
    public void Update()
    {
        //total_scr = Cube1.GetComponent("Cube1Pick") as MonoBehaviour;
        print(total_scr);
        //isStand = true;
        // var isGrounded = controller with attribute isGrounded. Touched the ground
        isGrounded = controller.isGrounded;
        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        // Move by wsad, up, left, right, down.
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Checking - if we on the ground, if UNDERground, any way will be on the ground
        if(isGrounded && !isProne)
        {
            isStand = true;
            isWalk = false;
            isJump = false;
            isFly = false;
            //isProne = false;

            //playerVelocity.y = 0f;
            //print("Stand");
        }
        // Initialize head move

        
        if(move != Vector3.zero && !isSprint && !isJump && !isFly && isStand)
        {
            isWalk = true;
            //print("Walk");
        }

        // If add !isSprint then we cant increase speed, speed up, over basic sprint
        if(move != Vector3.zero && Input.GetKeyDown(KeyCode.LeftShift) && !isSprint && isWalk && move != Vector3.back && !isProne && !isJump)
        {
            isSprint = true;
            isJump = false;
            playerVelocity.z += Mathf.Sqrt(playerSprintSpeed * 2f); 
            //print("Sprint");
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift) && isSprint)
        {
            isSprint = false;
            playerVelocity.z = 0;
            //print("Walk"); 
        }

        // Added isGrounded in IF and while jump he cannot prone - logic
        if(Input.GetKeyDown(KeyCode.C) && isStand)
        {
            isProne = true;
            isSprint = false;
            isStand = false;
            isWalk = false;
            isFly = false;
            isJump = false;

            Player.transform.rotation = Quaternion.Euler(0, 0, 90);
            // Player.transform.rotation = Quaternion.Slerp(from.rotation, to.rotation, timeCount);
            // timeCount = timeCount + Time.deltaTime;
            //print("Prone");
        }
            else if(Input.GetKeyDown(KeyCode.C) && !isStand && !isWalk) 
            {
            isProne = false;  
            isJump = false;  
            isGrounded = true;
            isStand = true;
            Player.transform.rotation = Quaternion.Euler(0, 0, 0);
            //print("Stand");    
            }


        if(Input.GetKeyDown(KeyCode.V) && isGrounded && !isProne && !isSprint)
        {  
            isJump = true;
            isGrounded = false;
            playerVelocity.y = Mathf.Sqrt(playerJumpHeight * -1.0f * gravityPlayer);
            //print("Jump");
        }
        
        // I falling down quicker 
        if(Input.GetButtonDown("Fire1") && !isGrounded)
        {
            isGrounded = true;
            playerVelocity.y -= Mathf.Sqrt(playerJumpHeight * -2 * gravityPlayer);    
            //print("Quick down");
        }

        if(Input.GetKeyDown(KeyCode.F) && !isProne)
        {
            //isSprint = true;
            isGrounded = false;
            isFly = true;
            isWalk = false;
            isJump = false;
            isFlyMoving = true;
            isProne = false;
            isStand = true;
            playerVelocity.y += Mathf.Sqrt(playerFlying * 2.0f); 
            //print("Fly");
        }
        else if(Input.GetKeyUp(KeyCode.F))
        {
            isFlyMoving = false;
            //print("Not flying");

        }

        if(move != Vector3.zero && Input.GetKeyDown(KeyCode.Space) && !isFlyTurbo && !isSprint && !isWalk)
        {
            isFlyTurbo = true;
            playerVelocity.z += Mathf.Sqrt(playerSprintSpeed * 2f);
            //print("Turbo on");
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            isFlyTurbo = false;
            playerVelocity.z = 0f;
            //print("Not a turbo");
        }

        playerVelocity.y += gravityPlayer * Time.deltaTime;

        // Motion of jump. Without no jump. 
        controller.Move(playerVelocity * Time.deltaTime);
        

        // // Horizontal rotate of mouse
        // float horizontal = horizontalRotateSpeed * Input.GetAxis("Mouse X");
        
        // // Vertical rotate of mouse
        // float vertical = verticalRotateSpeed * Input.GetAxis("Mouse Y");
        
        // // Enable rotation. We use vars horizontal and vertical
        // transform.Rotate(horizontal, 0, vertical);

        // Two cubes for rotate in Self - Applies transformation relative to the local coordinate system. If you want 
        // to move something to a relative position of some another object(player, car, phone box).
        // And in World - to the world coordinate, (0, 0, 0). As default.
        //Cube2.transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
        //Cube3.transform.Rotate(xAngle, yAngle, zAngle, Space.World);

        RaycastHit hits;
        if(Physics.Raycast(transform.position, transform.forward, out hits, 101) && gameObject != null)
        {       
            hits.collider.gameObject.GetComponent<Renderer>().material.color = Color.black;
            Destroy(hits.collider.gameObject, lifeTimeObject);
            //Select(hits.collider.gameObject);
            print(hits.collider.gameObject.name);
        }

        Debug.DrawRay(transform.position, transform.forward * 101, Color.red, duration: 2f, false); 

        if(isProne && isBottom && isWater)
        {
            isProne = true;
            isWater = true;
            isBottom = true;
        }
    }
    // Touch the object sprite or collider, not just touch
    void OnTriggerEnter(Collider other) 
    {
        if(other.name == "Lake" && !isWater)
        {
            isWater = true;
            isBottom = false;
            //print("In lake");
        } 

        if(other.name == "BottomLake")
        {
            isWater = true;
            isBottom = true;

            //print("Bottom Lake");
        }
    
    }

    void OnTriggerStay(Collider other)
    {
        if(other.name == "Lake" && isWater)
        {
            isWater = true;
            //print("Still in water");
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if(other.name == "Lake" && isWater)
        {
            isWater = false;
            //print("Out of the water");
        }

        if(other.name == "BottomLake" && isWater)
        {
            isWater = true;
            isBottom = false;
            //print("Not on bottom");
        }
    }
}

