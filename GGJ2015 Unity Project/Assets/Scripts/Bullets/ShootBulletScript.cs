using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class ShootBulletScript : MonoBehaviour {

    public TextState textState;
    public GameObject bulletPrefab;
    public string[] ignoreTags;
    Rigidbody2D rb;

    void Start()
    {
        rb = rigidbody2D;
    }
	
	// Update is called once per frame
    public RandomText FireBullet(Vector2 direction, Vector2 offsetFromCenterOfGameObject, bool goodBad)
    {
        return FireBullet(rb.position, direction, offsetFromCenterOfGameObject, goodBad);
    }

    public RandomText FireBullet(Vector2 position, Vector2 direction, Vector2 offsetFromCenterOfGameObject, bool goodBad)
    {
        RandomText script = ((GameObject)Instantiate(bulletPrefab, position + (Vector2)transform.TransformDirection(offsetFromCenterOfGameObject), Quaternion.identity)).GetComponent<RandomText>();
        script.Initialize(textState, direction, goodBad);
        return script;
    }
}
