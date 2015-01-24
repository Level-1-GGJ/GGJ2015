using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour {

    Rigidbody2D rb;

    public Vector2 Position
    {
        get { return rb.position; }
    }

    public bool IsKinematic
    {
        get { return rb.isKinematic; }
        set { rb.isKinematic = value; }
    }

    public float GravityAmount
    {
        get { return rigidbody2D.gravityScale; }
        set { rb.gravityScale = value; }
    }

	// Use this for initialization
	void Start () {
        rb = rigidbody2D;
        rb.fixedAngle = true;
        rb.sleepMode = RigidbodySleepMode2D.NeverSleep;
	}

    public void Move(Vector2 direction)
    {
        rb.position = (rb.position + direction);
    }

    public void AddForce(Vector2 force)
    {
        rb.AddForce(force);
    }

    public void SetVelocityY(float vel)
    {
        float vx = rb.velocity.x;
        rb.velocity = new Vector2(vx, vel);
    }

    public void SetVelocityX(float vel)
    {
        rb.velocity = new Vector2(vel, rb.velocity.y);
    }

    public void SetVelocity(Vector2 vel)
    {
        rb.velocity = vel;
    }
}
