using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovementController))]
public class PlayerMovement : MonoBehaviour 
{
    MovementController mc;

    public Vector2 horizontalDistance;
    public Vector2 verticalDistance;
    public Vector2 jumpDistance;
    public Vector2 dashDistance;

    public bool flying = true;

    public float jumpHeight = 10;

    //dashing! variables
    public float resetTimer = .5f;
    float dashTime;
    public float maxDashTime;
    public float dashSpeed;
    int buttonClicks= 0;
    bool dashing = false;

	// Use this for initialization
	void Start () 
    {
        mc = GetComponent<MovementController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            //if the timer is still running from the last push and the button was pushed once
            if (resetTimer > 0 && buttonClicks == 1)
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
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (resetTimer > 0 && buttonClicks == 1)
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
            mc.Velocity = dashDistance;

            //if i have exceeded the amount of dash time
            if (dashTime > maxDashTime)
            {
                //stop dashing
                dashing = false;
                //make my velocity 0/stop dashing
                mc.Velocity = Vector2.zero;
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
}
