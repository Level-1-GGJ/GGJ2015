using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour {

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = rigidbody2D;
        rb.fixedAngle = true;        
	}

    public void Move(Vector2 direction)
    {
        rb.MovePosition(rb.position + direction);
    }

    void AddForce(Vector2 force)
    {
        rb.AddForce(force);
    }
}
