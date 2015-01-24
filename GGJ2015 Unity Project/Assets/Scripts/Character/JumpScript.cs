using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(PlayerMovement))]
public class JumpScript : MonoBehaviour {

    MovementController mc;
    PlayerMovement pm;

    public float jumpHeight = 10;

    public bool hasDoubleJump = true;
    public bool canFirstJump = false;

    public bool canJump = false;

    public bool jumpButtonPressed = false;

	// Use this for initialization
	void Start () {
        mc = GetComponent<MovementController>();
        pm = GetComponent<PlayerMovement>();
	}

    void Update()
    {
        if (canJump && !jumpButtonPressed)
        {
            jumpButtonPressed = Input.GetButtonDown("Jump");
        }
    }

	// Update is called once per frame
	void FixedUpdate () {
        if (!pm.dashing && jumpButtonPressed)
        {
            jumpButtonPressed = false;
            mc.SetVelocityY(0);
            mc.AddForce(Vector2.up * jumpHeight * 10);
            if (hasDoubleJump && canFirstJump)
            {
                canFirstJump = false;
            }
            else
            {
                canJump = false;
            }
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Floor") || col.gameObject.CompareTag("Car"))
        {
            canFirstJump = true;
            canJump = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Floor") || col.gameObject.CompareTag("Car"))
        {
            canFirstJump = false;
            if (!hasDoubleJump) canJump = false;
        }
    }
}
