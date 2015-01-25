using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class ThingDiesNowScript : MonoBehaviour {

    [HideInInspector]
    public bool invuln = false;
    public float deathTimer = 0;
    public string[] tagsThatKillMe;

    void OnTriggerEnter2D(Collider2D col)
    {
        CollisionCheck(col.gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        CollisionCheck(col.gameObject);
    }

    void CollisionCheck(GameObject col)
    {
        if (!invuln)
        {
            for (int i = 0; i < tagsThatKillMe.Length; i++)
            {
                if (col.CompareTag(tagsThatKillMe[i]))
                {
                    SendMessage("PrepForDeath", SendMessageOptions.DontRequireReceiver);
                    Invoke("Die", deathTimer);
                    break;
                }
            }
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
