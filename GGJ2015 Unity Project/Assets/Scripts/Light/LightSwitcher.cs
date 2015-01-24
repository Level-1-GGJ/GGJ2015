using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovementController))]
public class LightSwitcher : MonoBehaviour 
{
    public Texture[] lights;
    public float greenTime;
    public float yellowTime;
    public float redTime;

    float timePassed = 0;
    public int curLight = 0;

    public bool isGreen;
    public bool isYellow;
    public bool isRed;

    MovementController mc;
    MovingPlatformScript car;

	// Use this for initialization
	void Start () 
    {
        mc = GetComponent<MovementController>();
        car = GameObject.FindGameObjectWithTag("Car").GetComponent<MovingPlatformScript>();
        isGreen = true;
        renderer.material.mainTexture = lights[curLight];
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (car.onCar)
        {
            if (isGreen)
            {
                if (timePassed > greenTime)
                {
                    timePassed = 0;
                    curLight++;
                }
            }
            else if (isYellow)
            {
                if (timePassed > yellowTime)
                {
                    timePassed = 0;
                    curLight++;
                }
            }
            else if (isRed)
            {
                if (timePassed > redTime)
                {
                    timePassed = 0;
                    curLight++;
                }
            }
            timePassed += Time.deltaTime;
            renderer.material.mainTexture = lights[curLight % 3];
        }
	}
}
