using UnityEngine;
using System.Collections;

[RequireComponent(typeof(JumpScript))]
[RequireComponent(typeof(ThingDiesNowScript))]
public class PlayerAnimator : MonoBehaviour {

    public GameObject book;

    bool died = false;
    Animation anim;
    JumpScript jS;
    PlayerMovement pm;
    ThingDiesNowScript tdns;
	// Use this for initialization
	void Start () {
        jS = GetComponent<JumpScript>();
        pm = GetComponent<PlayerMovement>();
        tdns = GetComponent<ThingDiesNowScript>();
        anim = GetComponentInChildren<Animation>();
        anim["Idle"].speed = .1f;
	}
	
	// Update is called once per frame
	void Update () {
        book.SetActive(false);
        if (died)
        {
            anim.Play("Death");
        }
        else if (pm.flying && pm.canFly)
        {
            anim.Play("Flight");
        }
        else if (tdns.invuln)
        {
            anim.Play("Protection");
            book.SetActive(true);
        }
        else if (pm.dashing && pm.canActuallyDash)
        {
            anim.Play("Dash");
        }
        else if (jS.jumpCount > 0)
        {
            anim.Play("Jump " + jS.jumpCount);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.Play("Walk");
        }
        else
        {
            anim.Play("Idle");
        }
	}

    void PrepForDeath()
    {
        died = true;
    }
}
