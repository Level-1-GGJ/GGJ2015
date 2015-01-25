using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class RespawnPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
        collider2D.isTrigger = true;
        rigidbody2D.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            DeathController.sharedController.spawnerLocation = gameObject;
        }
    }
}
