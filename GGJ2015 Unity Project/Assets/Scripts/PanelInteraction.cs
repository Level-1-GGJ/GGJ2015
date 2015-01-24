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
	public bool overdrive;
    bool keyPressed = false;
	// Use this for initialization
	void Start () 
    {
        playerMC = player.GetComponent<MovementController>();
	}

    void Update()
    {
        if (!keyPressed) keyPressed = Input.GetKeyDown(KeyCode.E);
    }

	// Update is called once per frame
	void FixedUpdate () 
    {
        Vector2 dist = playerMC.Position - new Vector2(transform.position.x, transform.position.y);
        if (overdrive)
        {
            if (keyPressed)
            {
                activated = !activated;
                timePassed = 0;
                keyPressed = false;
            }
        }

        timePassed++;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag ("Player"))
		{
			overdrive = true;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.CompareTag ("Player"))
		{
			overdrive = false;
		}
	}


}
