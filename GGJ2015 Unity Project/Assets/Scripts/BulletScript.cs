using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovementController))]
public class BulletScript : MonoBehaviour {

    public float speed;

    MovementController mc;
    Vector2 direction;
    
	// Use this for initialization
	void Start () {
        mc = GetComponent<MovementController>();
        mc.IsKinematic = true;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        mc.Move(direction * speed);
	}

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        if (direction != Vector2.zero)
        {
            transform.right = direction;
        }
    }
}
