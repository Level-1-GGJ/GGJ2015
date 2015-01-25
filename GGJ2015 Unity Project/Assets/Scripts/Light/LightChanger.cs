using UnityEngine;
using System.Collections;

public class LightChanger : MonoBehaviour 
{
    LightSwitcher streetLight;
    public int littleLight;
    
	// Use this for initialization
	void Start () 
    {
        streetLight = GameObject.FindGameObjectWithTag("StreetLight").GetComponent<LightSwitcher>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (streetLight.curLight%3 == littleLight)
        {
            light.enabled = true;
        }
        else
        {
            light.enabled = false;
        }
	}
}
