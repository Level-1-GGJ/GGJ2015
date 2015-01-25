using UnityEngine;
using System.Collections;

public class DeathController : MonoBehaviour {

    public static DeathController sharedController;

    public GameObject spawnerLocation;
    public GameObject playerPrefab;

    GameObject player;

    void Awake()
    {
        sharedController = this;
        player = GameObject.FindWithTag("Player");
    }

	// Use this for initialization
    public void Update()
    {
        if (!player)
        {
            player = GameObject.FindWithTag("Player");
            if (!player)
            {
                Instantiate(playerPrefab, spawnerLocation.transform.position, Quaternion.identity);
            }
        }
    }
}