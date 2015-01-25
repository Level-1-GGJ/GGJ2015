using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {

    public string nextScene;
	// Use this for initialization
	void Start () {
        
	}

    public void load()
    {
        Application.LoadLevel(nextScene);
    }
}
