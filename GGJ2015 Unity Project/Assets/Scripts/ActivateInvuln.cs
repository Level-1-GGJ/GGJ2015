using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(ThingDiesNowScript))]
public class ActivateInvuln : MonoBehaviour {
    bool dead = false;
    PlayerMovement pm;
    ThingDiesNowScript tdns;
	// Use this for initialization
	void Start () {
        pm = GetComponent<PlayerMovement>();
        tdns = GetComponent<ThingDiesNowScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!dead)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                pm.canControl = false;
                tdns.invuln = true;
            }
            else
            {
                pm.canControl = true;
                tdns.invuln = false;
            }
        }
	}

    void PrepForDeath()
    {
        dead = true;
    }
}
