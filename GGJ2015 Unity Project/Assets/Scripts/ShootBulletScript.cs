using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class ShootBulletScript : MonoBehaviour {

    public GameObject bulletPrefab;
    Rigidbody2D rb;

    void Start()
    {
        rb = rigidbody2D;
    }
	
	// Update is called once per frame
    public BulletScript FireBullet(Vector2 direction, Vector2 offsetFromCenterOfGameObject)
    {
        BulletScript script = ((GameObject)Instantiate(bulletPrefab, rb.position + (Vector2)transform.TransformDirection(offsetFromCenterOfGameObject), Quaternion.identity)).GetComponent<BulletScript>();
        script.Initialize(direction, gameObject.tag);
        return script;
    }
}
