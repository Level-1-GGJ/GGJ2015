using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ShootBulletScript))]
public class Spawner : MonoBehaviour {

    [HideInInspector]
    public Spawner sharedInstance;
    ShootBulletScript shoot;
    public int frequency;
    float screenWidthInUnits;
    float lowerScreenY;
    float upperScreenY;

    [HideInInspector]
    public GameObject player;

    void Awake()
    {
        sharedInstance = this;
    }

	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        shoot = GetComponent<ShootBulletScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!player)
        {
            player = GameObject.FindWithTag("Player");
        }

        if (player && frequency != 0 && Random.Range(1, frequency+1) == frequency)
        {
            screenWidthInUnits = (Screen.width / 100f);
            upperScreenY = (Screen.height / 100f);
            lowerScreenY = -upperScreenY;
            RandomText t = shoot.FireBullet(player.transform.position, -Vector2.right, new Vector2(screenWidthInUnits, Random.Range(lowerScreenY, upperScreenY)), false);
            t.textSpeed = .05f;
            t.tag = "Deadly";
        }
	}
}
