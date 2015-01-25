using UnityEngine;
using System.Collections;

public class QuoteScreenController : MonoBehaviour {
    CameraController cameraController;
    public float secondsToWait = 3f;
    public string nextScene;
	// Use this for initialization
	void Start () {
        cameraController = Camera.main.GetComponent<CameraController>();
        cameraController.StopAllCoroutines();
        StartCoroutine(QuoteCoroutine());
	}

    IEnumerator QuoteCoroutine()
    {
        yield return cameraController.StartCoroutine(cameraController.FadeInCoroutine(.03f));
        yield return new WaitForSeconds(secondsToWait);
        yield return cameraController.StartCoroutine(cameraController.FadeOutCoroutine(.03f));
        Application.LoadLevel(nextScene);
    }
}
