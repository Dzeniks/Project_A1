using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = System.Random;
using Timer = System.Timers.Timer;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class NewMovement : MonoBehaviour
{
    public Camera MainCam;
    public float playerSpeed = 10f, playerFriction = -10f, SlideSpeed = 0.01f;
    private float touchTime, DiffY, DiffX, height, heightMax, width;
    public bool stopRun = true;
    public float jumpTime;
    public bool isGrounded;
    private Rigidbody rb;
    private Vector2 startTouchPosition, endTouchPosition, prevPos, bottomScreen;
    private Vector3 position, velocity;

    

    // Unity functions
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(stopRun){
            moving_forward();
            Movement();
        }
    }

    private void moving_forward()
    {
        if (isGrounded == false)
        {
            rb.velocity = new Vector3(0, playerFriction, (float) (playerSpeed * 1.2));
        }
        else if (isGrounded == true)
        {
            rb.velocity = new Vector3(0, playerFriction, playerSpeed);
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        // Check if player is on ground
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
    // Part of script
    private void Movement()
    {
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved){
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * SlideSpeed,
                    transform.position.y,
                    transform.position.z);
            }
        }
    }
}
