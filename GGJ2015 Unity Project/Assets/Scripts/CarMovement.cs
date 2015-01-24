using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(MovingPlatformScript))]
public class CarMovement : MonoBehaviour 
{
    MovementController mc;
    MovementController playerMC;
    LightSwitcher orders;
    MovingPlatformScript car;
    BoxCollider2D carCollider;

    public float greenSpeed;
    public float yellowSpeed;
    public float redSpeed;

	// Use this for initialization
	void Start () 
    {
        mc = GetComponent<MovementController>();
        playerMC = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>();
        orders = GameObject.FindGameObjectWithTag("StreetLight").GetComponent<LightSwitcher>();
        car = GameObject.FindGameObjectWithTag("Car").GetComponent<MovingPlatformScript>();
        carCollider = GameObject.FindGameObjectWithTag("Car").GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Debug.Log("Platform movement");
        if (car.onCar && car.currentIndex > 0)//playerMC.Position.x < carCollider.center.x + carCollider.size.x && playerMC.Position.x > carCollider.center.x - carCollider.size.x)
        {
            //Debug.Log("on platform");
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
        else
        {
            //Debug.Log("off car");
            car.timeToVisitAllPoints = 0;
        }
	}
}
