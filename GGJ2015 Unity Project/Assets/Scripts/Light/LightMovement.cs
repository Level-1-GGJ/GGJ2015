using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovementController))]
public class LightMovement : MonoBehaviour 
{
    MovementController playerController;
    MovementController mc;

    public Vector2 rightBound;
    public Vector2 leftBound;

	// Use this for initialization
	void Start () 
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>();
        mc = GetComponent<MovementController>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (playerController.Position.x < rightBound.x && playerController.Position.x > leftBound.x)
        {
            mc.Position = new Vector2(playerController.Position.x,mc.Position.y);
        }
	}
}
