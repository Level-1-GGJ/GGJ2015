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
    public float resetTimerValue = .5f;
	public float cooldownTimerValue= 1f;
    float dashTime;
    public float maxDashTime;
    public float dashSpeed;
    int buttonClicks= 0;
    public bool canDash = true;
    public bool dashing = false;
	float cooldownTimer;
	float resetTimer;

    public bool APressed = false;
    public bool DPressed = false;
    public bool shifting = false;
	bool lastLeft =false;

    public Vector2 relativeDeathVelocity = new Vector2(-.1f, 4f);

	// Use this for initialization
	void Start () 
    {
        mc = GetComponent<MovementController>();
        horizontalDistance = Vector2.right * speed;
        verticalDistance = Vector2.up * speed;
		cooldownTimer = cooldownTimerValue;
		resetTimer = resetTimerValue;
	}

    void Update()
    {
        if (!APressed) APressed = Input.GetKeyDown(KeyCode.A);
        if (!DPressed) DPressed = Input.GetKeyDown(KeyCode.D);
        if (!shifting) shifting = Input.GetKeyDown(KeyCode.LeftShift);
		flying = Input.GetKey (KeyCode.LeftControl);
    }

	// Update is called once per frame
	void FixedUpdate () 
    {
        
        if (!canControl)
            return;

        if (flying)
        {
			mc.SetVelocityY(0);
            mc.GravityAmount = 0;
            if (Input.GetKey(KeyCode.W))
            {
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
            if (canDash && !dashing && shifting)
            {
				if(cooldownTimer<0)
				{
                    shifting = false;
	             	//make the dashing distance be left and at the dash speed
	             	dashDistance.x = -dashSpeed;
	                //turn on the dashing bool
	                dashing = true;
	                //reset the timer for dashing
	                dashTime = 0;
				}
           	}
                //if the second button hasnt been pressed yet
            else
            {
                //start the timer for double tapping
                resetTimer = .5f;
                //and add one to the number of taps
                buttonClicks++;
				//Sets the lastLeft boolean to true for future reference.
            }
			lastLeft= true;
        }
            //this is the same as left except right
        else if (DPressed)
        {
	        transform.rotation = Quaternion.Euler(0, 0, 0);
	        DPressed = false;
	        if (canDash && !dashing && shifting)
	        {
				if(cooldownTimer<0)
				{
                    shifting = false;
	            	dashDistance.x = dashSpeed;
	            	dashing = true;
	            	dashTime = 0;
				}
	         }
	         else
	         {
	             resetTimer = .5f;
	             buttonClicks++;
				//Sets the lastLeft boolean to true for future reference.
	         }
			lastLeft = false;
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
            if (!flying)
            {
                canDash = false;
            }

            //if i have exceeded the amount of dash time
            if (dashTime > maxDashTime)
            {
                //stop dashing
                dashing = false;
				//Resetting the cooldown to begin counting down again.
                cooldownTimer = cooldownTimerValue;
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

		cooldownTimer -= 1 * Time.deltaTime;
	}

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Floor"))
        {
            canDash = true;
        }
    }

    void PrepForDeath()
    {
        mc.SetVelocity(new Vector2(transform.right.x * relativeDeathVelocity.x, relativeDeathVelocity.y));
        canControl = false;
    }
}
