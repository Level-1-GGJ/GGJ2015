using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovementController))]
public class DoorMovement : MonoBehaviour
{
    public PanelInteraction panelScript;
    public GameObject panel;
    public MovementController mc;

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
	void Update () 
    {
        Debug.Log(openPos + " time: " + panelScript.timePassed);
        if (panelScript.activated && panelScript.timePassed < 12)
        {
            Debug.Log("where re you going?");
            mc.Move((openPos - new Vector2(transform.position.x, transform.position.y))/12);

        }
        else if(!panelScript.activated && panelScript.timePassed < 12)
        {
            Debug.Log("what about you?");
            mc.Move((closedPos - new Vector2(transform.position.x, transform.position.y))/12);
        }
        Debug.Log("nothing?");
	}
}
