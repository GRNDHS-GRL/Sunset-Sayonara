using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody Ball;
    public float forwardAccel = 8f;
    public float reverseAccel = 4f;
    public float maxSpeed = 50f;
    public float turnStrength = 180;
    public float gravityForce = 10f;
    public float dragOnGround = 3f;

    public Animator animator;

    private float speedInput, turnInput;

    private bool grounded;

    public LayerMask whatIsGround;
    public float groundRayLength = .5f;
    public Transform groundRayPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        Ball.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        speedInput = 0f;
        if (Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel * 1000f;
            animator.SetFloat("Speed", 1);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
           speedInput = Input.GetAxis("Vertical") * reverseAccel * 1000f;
           animator.SetFloat("Speed", 1);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }

        turnInput = Input.GetAxis("Horizontal");

        if (grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
        }

        if (Input.GetButtonDown("Left"))
        {
            animator.SetBool("IsTurnLeft", true);
        }
        else if (Input.GetButtonUp("Left"))
        {
            animator.SetBool("IsTurnLeft", false);
        }

        if (Input.GetButtonDown("Right"))
        {
            animator.SetBool("IsTurnRight", true);
        }
        else if (Input.GetButtonUp("Right"))
        {
            animator.SetBool("IsTurnRight", false);
        }

        transform.position = Ball.transform.position;
    }

    private void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;
        
        if(Physics.Raycast(groundRayPoint.position, -transform.up, out hit, groundRayLength, whatIsGround))
        {
            grounded = true;

            //this is the line you'll wanna get rid off if the sprite looks fucky going up ramps n shit
            //transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        if (grounded)
        {
            Ball.drag = dragOnGround;
            
            if (Mathf.Abs(speedInput) > 0)
            {
                Ball.AddForce(transform.forward * speedInput);
            }
        }
        else
        {
            Ball.drag = 0.1f;
            
            Ball.AddForce(Vector3.up * -gravityForce * 100f);
        }
    }
}
