using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(MovingPlatformScript))]
public class CarMovement : MonoBehaviour 
{
    MovementController mc;
    LightSwitcher orders;
    MovingPlatformScript car;

    public float greenSpeed;
    public float yellowSpeed;
    public float redSpeed;

	// Use this for initialization
	void Start () 
    {
        mc = GetComponent<MovementController>();
        orders = GameObject.FindGameObjectWithTag("StreetLight").GetComponent<LightSwitcher>();
        car = GameObject.FindGameObjectWithTag("Car").GetComponent<MovingPlatformScript>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (orders.curLight % 3 == 0)
        {
            car.timeToVisitAllPoints = greenSpeed;
        }
        else if (orders.curLight % 3 == 1)
        {
            car.timeToVisitAllPoints = yellowSpeed;
        }
        else if (orders.curLight % 3 == 2)
        {
            car.timeToVisitAllPoints = redSpeed;
        }
	}
}
