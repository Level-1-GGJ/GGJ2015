using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MovementController))]
public class PanelInteraction : MonoBehaviour 
{
    public bool activated = false;
    public MovementController playerMC;
    public GameObject player;
    public GameObject door;
    public float timePassed;

	// Use this for initialization
	void Start () 
    {
        playerMC = player.GetComponent<MovementController>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        Vector2 dist = playerMC.Position - new Vector2(transform.position.x, transform.position.y);
        if (dist.magnitude < 5)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                activated = !activated;
                timePassed = 0;
            }
        }

        timePassed++;
	}
}
