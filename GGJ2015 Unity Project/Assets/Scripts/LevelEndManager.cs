using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class LevelEndManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        collider2D.isTrigger = true;
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.SendMessage("PrepForDeath");
            StartCoroutine(ExitScene());
        }
    }

    IEnumerator ExitScene()
    {
        CameraController cameraController = Camera.main.GetComponent<CameraController>();
        yield return cameraController.StartCoroutine(cameraController.FadeOutCoroutine(.02f));
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
