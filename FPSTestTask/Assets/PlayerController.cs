using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 velocity;
    public Vector3 move;
    public float Speed;
    public GameObject mCameraHolder;
    public bool isSpriting;
    public bool isCrouching;
    public bool isGrouned;
    public float SprintSpeed;
    public float CrouchSpeed;
    public float WalkSpeed;
    float Crouchheight;
    float height;
     public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    public float gravity = - 9.81f;
    public static PlayerController Instance;
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Crouchheight = mCameraHolder.transform.position.y - 0.7f;
        height = mCameraHolder.transform.position.y;
        isCrouching = false;
    }

    // Update is called once per frame
    void Update()
    {
        Walk(Speed);
        Sprint();
        Jump();
        Crouch();

        if(Input.GetKeyDown(KeyCode.R)) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    void Walk(float speed)
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = (transform.right * x + transform.forward * z);

        controller.Move(move * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }

    void Jump()
    {
        isGrouned = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrouned && velocity.y < 0) velocity.y = -2f;

        if(Input.GetButtonDown("Jump") && isGrouned)  velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        
        velocity.y += gravity * Time.deltaTime;
    }

    void Sprint()
    {
        if(Input.GetKey(KeyCode.LeftShift) && !isCrouching)
        {
            Speed = SprintSpeed;
            isSpriting = true;
        }
        else if(!isCrouching)
        {
            Speed = WalkSpeed;
            isSpriting = false;
        }
    }

    void Crouch()
    {   
        if(Input.GetKey(KeyCode.LeftControl))
        {
            isSpriting = false;
            Speed = CrouchSpeed;
            mCameraHolder.transform.position = Vector3.Lerp(mCameraHolder.transform.position , new Vector3(mCameraHolder.transform.position.x,Crouchheight,mCameraHolder.transform.position.z), 10 * Time.deltaTime);
        }
        else
        {
            if(isGrouned)
            {
                mCameraHolder.transform.position = Vector3.Lerp(mCameraHolder.transform.position , new Vector3(mCameraHolder.transform.position.x,height,mCameraHolder.transform.position.z), 10 * Time.deltaTime);
            }
            else
            {
                mCameraHolder.transform.position = Vector3.Lerp(mCameraHolder.transform.position , new Vector3(mCameraHolder.transform.position.x,mCameraHolder.transform.position.y,mCameraHolder.transform.position.z), 10 * Time.deltaTime);
            }
        }
    }
}
