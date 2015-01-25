using UnityEngine;
using System.Collections;

public class LightSpawner : MonoBehaviour 
{
    Spawner spawn;
    LightSwitcher lights;
    MovingPlatformScript car;

    public int greenSpawnRate;
    public int yellowSpawnRate;
    public int redSpawnRate;

	// Use this for initialization
	void Start () 
    {
        spawn = GetComponent<Spawner>();
        lights = GetComponent<LightSwitcher>();
        car = GameObject.FindGameObjectWithTag("Car").GetComponent<MovingPlatformScript>();
        spawn.frequency = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (car.onCar)
        {
            if (lights.curLight == 0)
            {
                spawn.frequency = greenSpawnRate;
            }
            else if (lights.curLight == 1)
            {
                spawn.frequency = yellowSpawnRate;
            }
            else if (lights.curLight == 2)
            {
                spawn.frequency = redSpawnRate;
            }
        }
        else
        {
            spawn.frequency = 0;
        }
	}
}
