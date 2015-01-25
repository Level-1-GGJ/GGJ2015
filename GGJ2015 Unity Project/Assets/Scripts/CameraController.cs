﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    public Vector2 offset = new Vector2(0,1);
    public GameObject fadeViewBlocker;
    GameObject player;
    public float maxDistanceFromPlayer = 3;
    bool camResetStarted = false;
	// Use this for initialization
	void Start () {
        player = GameObject.FindWithTag("Player");
        fadeViewBlocker.renderer.material.color = new Color(0, 0, 0, 1);
        StartCoroutine(FadeInCoroutine(.02f));
	}
	
	// Update is called once per frame
	void Update () {
        if (player)
        {
            Debug.Log(Vector2.Distance(player.transform.position, transform.position));
            if (Vector2.Distance(player.transform.position, transform.position) > maxDistanceFromPlayer && !camResetStarted)
            {
                camResetStarted = true;
                StopAllCoroutines();
                StartCoroutine(CameraReset());
            }
            else
            {
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10) + (Vector3)offset;
            }
        }
        else
        {
            player = GameObject.FindWithTag("Player");
        }
	}

    IEnumerator CameraReset()
    {
        yield return StartCoroutine(FadeOutCoroutine(.1f));
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        yield return StartCoroutine(FadeInCoroutine(.1f));
        camResetStarted = false;
        yield break;
    }

    IEnumerator FadeInCoroutine(float speed)
    {
        Debug.Log("Entered Coroutine");
        Color color = fadeViewBlocker.renderer.material.color;
        while (color.a > 0)
        {
            yield return new WaitForFixedUpdate();
            color.a -= speed;
            fadeViewBlocker.renderer.material.color = color;

            Debug.Log(fadeViewBlocker.renderer.material.color = color);
        }
        yield break;
    }

    IEnumerator FadeOutCoroutine(float speed)
    {
        Debug.Log("Entered Coroutine");
        Color color = fadeViewBlocker.renderer.material.color;
        while (color.a < 1)
        {
            yield return new WaitForFixedUpdate();
            color.a += speed;
            fadeViewBlocker.renderer.material.color = color;

            Debug.Log(fadeViewBlocker.renderer.material.color = color);
        }
        yield break;
    }
}