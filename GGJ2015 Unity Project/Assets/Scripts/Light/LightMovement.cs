using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovementController))]
public class LightMovement : MonoBehaviour 
{
    MovementController playerController;
    MovementController mc;

    public Vector2 rightBound;
    public Vector2 leftBound;
    public Vector2 topBound;
    public Vector2 bottomBound;
    public Vector2 bufferZone;

	// Use this for initialization
	void Start () 
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementController>();
        mc = GetComponent<MovementController>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Debug.Log("made it to the light");
        if (playerController.Position.x < rightBound.x && playerController.Position.x > leftBound.x)
        {
            //Debug.Log("the light moves");
            mc.Position = new Vector2(playerController.Position.x,mc.Position.y);
        }
        if (playerController.Position.y < topBound.y && playerController.Position.y > bottomBound.y)
        {
            Debug.Log("move up");
            mc.Position = new Vector2(mc.Position.x, playerController.Position.y+bufferZone.y);
        }
	}
}
