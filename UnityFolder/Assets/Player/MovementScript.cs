using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    /// <summary>
    /// The speed the character moves at
    /// </summary>
    internal int MovementSpeed=50;
    /// <summary>
    /// The speed the Camera moves at
    /// </summary>
    private float CameraMovementSpeed = 5;
    private Rigidbody SelfRigidBody;
    private bool CanJump;
    private int JumpPower = 10;
    private bool JumpTimer, JumpTrigger;
    private float canJump;
    private Vector3 velocity;

    // Use this for initialization
    void Start () {
        SelfRigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        MoveForward();
        MoveBack();
        MoveLeft();
        MoveRight();
        Sprint();
        Crouch();
        Jump();
        Camera.main.transform.RotateAround(transform.position, Vector3.up, CameraMovementSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
       
	}

    private void FixedUpdate()
    {
        if (CanJump)
        {
            CanJump = false;
            SelfRigidBody.AddForce(0, JumpPower, 0, ForceMode.Impulse);
        }
    }

    /// <summary>
    /// Move the character forward
    /// </summary>
    public void MoveForward()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += MovementSpeed * Camera.main.transform.forward * Time.deltaTime;
        }
    }

    /// <summary>
    /// Move the charcater left
    /// </summary>
    public void MoveLeft()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= MovementSpeed * Camera.main.transform.right * Time.deltaTime;
        }
    }

    /// <summary>
    /// Move the character right
    /// </summary>
    public void MoveRight()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += MovementSpeed * Camera.main.transform.right * Time.deltaTime;
        }
    }

    /// <summary>
    /// Move the character backward
    /// </summary>
    public void MoveBack()
    {
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= MovementSpeed * Camera.main.transform.forward * Time.deltaTime;
        }
    }

    /// <summary>
    /// Interact with various objects in the world
    /// </summary>
    public void ActionKey()
    {
        if (Input.GetKey(KeyCode.E))
        {

        }
    }

    /// <summary>
    /// This will control the camera as controlled by the mouse
    /// </summary>
    public void RotateCamera()
    {
        Vector3 rotation = transform.eulerAngles;

        rotation.x += Input.GetAxis("Horizontal") * CameraMovementSpeed * Time.deltaTime;

        transform.eulerAngles = rotation;
    }

    /// <summary>
    /// This will make the character sprint
    /// </summary>
    public void Sprint()
    {
        if (Input.GetKey(KeyCode.F))
        {
            MovementSpeed = 500;
        }
        else MovementSpeed = 50;
    }

    /// <summary>
    /// This will make the character crouch
    /// </summary>
    public void Crouch()
    {
        if (Input.GetKey(KeyCode.RightControl))
        {
            MovementSpeed = 5;
        }
        else MovementSpeed = 50;
    }

    /// <summary>
    /// This will make the character jump
    /// </summary>
    public void Jump()
    {
        if (Input.GetKeyUp(KeyCode.Space)&&Time.time>canJump)
        {
            velocity = GetComponent<Rigidbody>().velocity;
            velocity.y = JumpPower;
            GetComponent<Rigidbody>().velocity = velocity;
            canJump = Time.time + 1.5f;
            StartCoroutine(StartJumpTimer());
            CanJump = true;

        }
    }
    public IEnumerator StartJumpTimer()
    {
        JumpTrigger = true;
        yield return new WaitForSeconds(25f);
    }

   
}
