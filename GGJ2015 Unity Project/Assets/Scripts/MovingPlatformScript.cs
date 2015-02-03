using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MovementController))]
public class MovingPlatformScript : MonoBehaviour {

    public Vector2[] pointsToVisit;
    public float timeToVisitAllPoints = 1;
	private MovementController mc;
	
    public MovementController MC
	{
		get { return mc; }
		set { mc = value; }
	}
    float speed = 0;
    int lastIndex;
    public int currentIndex;
    Vector2 currentDirection;
    float dist = 0;
    public bool onCar = false;

	// Use this for initialization
	void Start () {
        mc = GetComponent<MovementController>();
        
        dist += (pointsToVisit[0] - pointsToVisit[pointsToVisit.Length - 1]).magnitude;
        for (int i = 1; i < pointsToVisit.Length; i++)
        {
            dist += (pointsToVisit[i] - pointsToVisit[i - 1]).magnitude;
        }
        
        lastIndex = 0;
        currentIndex = 1;
        currentDirection = (pointsToVisit[currentIndex] - pointsToVisit[lastIndex]).normalized;
		onCar = false;
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeToVisitAllPoints != 0)
        {
            speed = (dist / timeToVisitAllPoints) * Time.fixedDeltaTime;
        }
        else
        {
            speed = 0;
        }

        if (Vector2.Dot(pointsToVisit[currentIndex] - mc.Position, currentDirection) < 0)
        {
            rigidbody2D.MovePosition(pointsToVisit[currentIndex]);
            lastIndex = currentIndex;
            currentIndex++;
            if (currentIndex == pointsToVisit.Length)
            {
                currentIndex = 0;
            }
            currentDirection = (pointsToVisit[currentIndex] - pointsToVisit[lastIndex]).normalized;
        }
        mc.Move(currentDirection * speed);
        foreach (Transform obj in transform)
        {
            MovementController mc2 = obj.GetComponent<MovementController>();
            if (mc2)
            {
                mc2.SetVelocityX(0);
                mc2.Move(currentDirection * speed);
            }
		} 
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Floor")
        {
            return;
        }

        if (Vector2.Dot((col.transform.position - transform.position), Vector2.up) > collider2D.bounds.extents.y / 2)
        {
            col.transform.parent = transform;
        }
        onCar = true;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "Floor")
        {
            return;
        }

        if (col.transform.parent == transform)
        {
            col.transform.parent = null;
        }
        
    }
}
