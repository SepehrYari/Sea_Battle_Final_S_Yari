using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOVEMENT : MonoBehaviour
{

    private bool isPaused = false;// for pausing


    [SerializeField] private GameObject Camera;// for the Camera
    Animator Animator; //for animation
    SpriteRenderer Ssprite; //for animation

    public float speed = 10; //for movement
    private Rigidbody rigidBody; //for movement
    private float horizontalInput; //for movement
    private float verticalInput; //for movement
    private Vector3 movedirection; //for movement

    public Vector3 jump; //for Jump
    public float jumpForce = 7.0f; //for Jump
    public bool isGrounded; //for Jump

    private bool isRotating = false; //for camera controls
    private Quaternion targetRotation; //for camera controls
    public float rotationSpeed = 90f; //for camera controls

    public float raycastDistance = 300f;// for the cannon
    public LayerMask Squid;// for the cannon


    //this function is to shoot a ray cast out of each cannon the player interacts will


    void Start()
    {
        Animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        Ssprite = GetComponent<SpriteRenderer>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    //function used for jumping  (currently, could be used for more)
    void OnCollisionStay()
    {
        isGrounded = true;
        Animator.SetBool("is Grounded", true);
    }


    void Update()
    {
        /* pause and exit function */

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0f : 1f;
            Application.Quit();

        }







        /* Movement Portion of code */

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        movedirection = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(movedirection * speed * Time.deltaTime);



        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            Animator.SetBool("Is moving", true);
            if (Input.GetKey(KeyCode.D))
            {
                Ssprite.flipX = true;
            }
            if (Input.GetKey(KeyCode.A))
            {
                Ssprite.flipX = false;
            }
        }
        else
        {
            Animator.SetBool("Is moving", false);
        }

        /* END of Movement Portion of code */


        /* Jump portion of code */



        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            isGrounded = false;
            rigidBody.AddForce(jump * jumpForce, ForceMode.Impulse);
            
            Animator.SetBool("is Grounded", false);

        }

        if (rigidBody.velocity.y > 0.1f)
        {
            Animator.SetBool("is jumping", true);
            Animator.SetBool("is falling", false);
        }
        else if (rigidBody.velocity.y < -0.1f)
        {
            Animator.SetBool("is jumping", false);
            Animator.SetBool("is falling", true);
        }
        else
        {
            Animator.SetBool("is jumping", false);
            Animator.SetBool("is falling", false);
        }

        /* END of Jump portion of code */

        /* start of crouch portion of code */
        if (isGrounded == true && Input.GetKey(KeyCode.LeftControl))
        {
            Animator.SetBool("is crouching", true);
            speed = 0.1f;
            jumpForce = 0.1f;
            

        }
        else
        {
            speed = 10f;
            jumpForce = 7f;
            Animator.SetBool("is crouching", false);
        }

        if (Input.GetKey(KeyCode.E))
        {
            Animator.SetBool("is interact", true);
        }
        else
        {
            Animator.SetBool("is interact", false);
        }

            /* end of crouch code */

            /* Camera code */

            if (Input.GetMouseButtonDown(0) && !isRotating) // Left mouse button is pressed
        {
            //rotate to the right
            isRotating = true;
            targetRotation = transform.rotation * Quaternion.Euler(0f, 90f, 0f);
        }

        if (Input.GetMouseButtonDown(1) && !isRotating) // right mouse button is pressed
        {
            //rotate to the right
            isRotating = true;
            targetRotation = transform.rotation * Quaternion.Euler(0f, -90f, 0f);
        }

        if (isRotating)
        {
            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Check if the rotation is complete
            if (transform.rotation == targetRotation)
            {
                isRotating = false;
            }
        }

        /* End of camera code  */

    }


}