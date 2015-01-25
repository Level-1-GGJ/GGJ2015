using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovementController))]
public class DoorMovement : MonoBehaviour
{
    public PanelInteraction panelScript;
    public GameObject panel;
    MovementController mc;

    public Vector2 openPos;
    public Vector2 closedPos;
    public Vector2 moveDist;

    public float speed;
	// Use this for initialization
	void Start () 
    {
        mc = GetComponent<MovementController>();
        panelScript = panel.GetComponent<PanelInteraction>();

        if (panelScript.activated)
        {
            openPos = new Vector2(transform.position.x, transform.position.y);
            closedPos = new Vector2(transform.position.x + moveDist.x, transform.position.y + moveDist.y);
        }
        else
        {
            closedPos = new Vector2(transform.position.x, transform.position.y);
            openPos = new Vector2(transform.position.x + moveDist.x, transform.position.y + moveDist.y);
        }
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (panelScript.activated)
        {
            mc.Move(Vector2.up * speed);
			if(mc.Position.y > openPos.y)
			{
				mc.Position = openPos;
			}
        }
        else if(!panelScript.activated)
        {
            mc.Move(-Vector2.up * speed);
			if(mc.Position.y < closedPos.y)
			{
				mc.Position = closedPos;
			}
        }
	}
}
