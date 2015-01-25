using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(ThingDiesNowScript))]
public class ActivateInvuln : MonoBehaviour {
    bool dead = false;
    PlayerMovement pm;
    ThingDiesNowScript tdns;
    bool wasInvincible = false;
    public GameObject Aura;
    public GameObject currentAura;
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
                if (!wasInvincible)
                {
                    currentAura = GameObject.Instantiate(Aura, this.gameObject.transform.position, Quaternion.identity) as GameObject;
                }
                wasInvincible = true;
            }
            else
            {
                if (wasInvincible)
                {
                    wasInvincible = false;
                    Destroy(currentAura);
                }
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
