using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovementController))]
public class BulletScript : MonoBehaviour {

    public float speed;

    MovementController mc;
    Vector2 direction;
    string ignoreTag;

	// Use this for initialization
	void Start () {
        mc = GetComponent<MovementController>();
        mc.IsKinematic = true;
        GetComponent<Collider2D>().isTrigger = true;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        mc.Move(direction * speed);
	}

    public void Initialize(Vector2 dir, string ignore)
    {
        direction = dir.normalized;
        if (direction != Vector2.zero)
        {
            transform.right = direction;
        }
        ignoreTag = ignore;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.CompareTag(ignoreTag))
            Destroy(gameObject);
    }
}
