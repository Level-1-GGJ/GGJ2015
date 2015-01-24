using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MovementController))]
public class MovingPlatformScript : MonoBehaviour {
    HashSet<Transform> collisions;

    public Vector2[] pointsToVisit;
    public float timeToVisitAllPoints = 1;

    MovementController mc;
    float speed = 0;
    int lastIndex;
    int currentIndex;
    Vector2 currentDirection;

	// Use this for initialization
	void Start () {
        mc = GetComponent<MovementController>();
        float dist = 0;
        dist += (pointsToVisit[0] - pointsToVisit[pointsToVisit.Length - 1]).magnitude;
        for (int i = 1; i < pointsToVisit.Length; i++)
        {
            dist += (pointsToVisit[i] - pointsToVisit[i - 1]).magnitude;
        }
        speed = (dist / timeToVisitAllPoints) * Time.fixedDeltaTime;
        lastIndex = 0;
        currentIndex = 1;
        currentDirection = (pointsToVisit[currentIndex] - pointsToVisit[lastIndex]).normalized;
        collisions = new HashSet<Transform>();
	}

    // Update is called once per frame
    void FixedUpdate()
    {
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
        else
        {
            rigidbody2D.MovePosition(rigidbody2D.position + currentDirection * speed);
        }
	}

    /*void OnCollisionEnter2D(Collision2D col)
    {
        if (Vector2.Dot((col.transform.position - transform.position), Vector2.up) > collider2D.bounds.extents.y / 2)
        {
            collisions.Add(transform);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.parent == transform)
        {
            collisions.Remove(transform);
        }
    }*/
}
