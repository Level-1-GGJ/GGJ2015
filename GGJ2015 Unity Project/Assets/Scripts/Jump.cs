using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour 
{
    public Vector2 horizontalDistance;
    public Vector2 verticalDistance;
    public Vector2 jumpDistance;

    public bool flying = true;

	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKey(KeyCode.W))
        {
            Debug.Log("Moving up");
            if (flying)
            {
                GetComponent<MovementController>().Move(verticalDistance);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<MovementController>().Move(-horizontalDistance);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Moving down");
            if (flying)
            {
                GetComponent<MovementController>().Move(-verticalDistance);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<MovementController>().Move(horizontalDistance);
        }
	}
}
