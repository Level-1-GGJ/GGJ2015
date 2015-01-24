using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovementController))]
public class PlayerMovement : MonoBehaviour 
{
    MovementController mc;

    public float speed = .1f;
    Vector2 horizontalDistance;
    Vector2 verticalDistance;
    Vector2 dashDistance;

    public bool canControl = true;

    public bool flying = true;

    //dashing! variables
    public float resetTimer = .5f;
    float dashTime;
    public float maxDashTime;
    public float dashSpeed;
    int buttonClicks= 0;
    public bool canDash = true;
    public bool dashing = false;

    bool APressed = false;
    bool DPressed = false;

    public Vector2 relativeDeathVelocity = new Vector2(-.1f, 4f);

	// Use this for initialization
	void Start () 
    {
        mc = GetComponent<MovementController>();
        horizontalDistance = Vector2.right * speed;
        verticalDistance = Vector2.up * speed;
	}

    void Update()
    {
        if (!APressed) APressed = Input.GetKeyDown(KeyCode.A);
        if (!DPressed) DPressed = Input.GetKeyDown(KeyCode.D);
    }

	// Update is called once per frame
	void FixedUpdate () 
    {
        if (!canControl)
            return;

        if (flying)
        {
            mc.GravityAmount = 0;
            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log(mc.Position);
                mc.Move(verticalDistance);
            }
            if (Input.GetKey(KeyCode.S))
            {
                mc.Move(-verticalDistance);
            }
        }
        else
        {
            mc.GravityAmount = 1;
        }

        //The dashing code was helped out by Montraydavis on unity answers
        //if im currently pushing left
        if (APressed)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            APressed = false;
            //if the timer is still running from the last push and the button was pushed once
            if (canDash && resetTimer > 0 && buttonClicks == 1)
            {
                Debug.Log("dashing! left");
                //make the dashing distance be left and at the dash speed
                dashDistance.x = -dashSpeed;
                //turn on the dashing bool
                dashing = true;
                //reset the timer for dashing
                dashTime = 0;
            }
                //if the second button hasnt been pressed yet
            else
            {
                //start the timer for double tapping
                resetTimer = .5f;
                //and add one to the number of taps
                buttonClicks++;
            }
        }
            //this is the same as left except right
        else if (DPressed)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            DPressed = false;
            if (canDash && resetTimer > 0 && buttonClicks == 1)
            {
                Debug.Log("dashing! right");
                dashDistance.x = dashSpeed;
                dashing = true;
                dashTime = 0;
            }
            else
            {
                resetTimer = .5f;
                buttonClicks++;
            }
        }

        //if the timer is runnning
        if (resetTimer > 0)
        {
            //subtract 1 times the delta time from the timer
            //turns out to be .016 per frame
            resetTimer -= 1 * Time.deltaTime;
        }
            //if the timer isnt runnning
        else
        {
            //reset the number of buttons clicked
            buttonClicks = 0;
        }

        //if im dashing
        if (dashing)
        {
            //force my velocity to the speed
            mc.SetVelocity(dashDistance);

            //if i have exceeded the amount of dash time
            if (dashTime > maxDashTime)
            {
                //stop dashing
                dashing = false;
                //make my velocity 0/stop dashing
                mc.SetVelocity(Vector2.zero);
            }

            //otherwise increment the total amount of dashing
            dashTime += Time.deltaTime;
        }
        // if not dashing move normally
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                mc.Move(-horizontalDistance);
            }
            if (Input.GetKey(KeyCode.D))
            {
                mc.Move(horizontalDistance);
            }
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            
        }
    }

    void PrepForDeath()
    {
        mc.SetVelocity(new Vector2(transform.right.x * relativeDeathVelocity.x, relativeDeathVelocity.y));
        canControl = false;
    }
}
