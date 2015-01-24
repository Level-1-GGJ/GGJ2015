using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovementController))]
public class PlayerMovement : MonoBehaviour 
{
    MovementController mc;

    public Vector2 horizontalDistance;
    public Vector2 verticalDistance;

    public bool flying = true;

	// Use this for initialization
	void Start () 
    {
        mc = GetComponent<MovementController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (flying)
        {
            mc.GravityAmount = 0;
            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log(mc.Position);
                mc.Move(verticalDistance);
            }
            if (Input.GetKey(KeyCode.S))
            {
                mc.Move(-verticalDistance);
            }
        }
        else
        {
            mc.GravityAmount = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            mc.Move(-horizontalDistance);
        }
        if (Input.GetKey(KeyCode.D))
        {
            mc.Move(horizontalDistance);
        }
	}
}
