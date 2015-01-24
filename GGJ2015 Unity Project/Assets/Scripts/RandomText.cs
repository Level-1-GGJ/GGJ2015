using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// The enum saying which section the text is in.
/// </summary>
public enum TextState
{
    Car,
    Office,
    Bar
}

/// <summary>
/// Instantiates a random text object that will fly across the screen.  Randomly chooses the text from one of several lists.
/// Created by Luna Meier.
/// </summary>
public class RandomText : MonoBehaviour {

    /// <summary>
    /// The location the text is spawned from.
    /// </summary>
    public TextState myLocation;

    /// <summary>
    /// Speed at which the text floats through the screen.
    /// </summary>
    public float textSpeed;

    /// <summary>
    /// Tracks whether the feeling is Positive or Negative
    /// </summary>
    public bool isPositive;

    /// <summary>
    /// Initializes the text box.
    /// </summary>
    /// <param name="myLocation">The location the thought is being spawned.</param>
    /// <param name="isPositive">Tracks whether the feeling is Positive or Negative.  True == positive.</param>
    /// /// <param name="textSpeed">Tracks the speed at which the text moves each fixedUpdate.  Negative moves left.</param>
    public void Initialize(TextState myLocation, bool isPositive, float textSpeed)
    {
        this.myLocation = myLocation;
        this.isPositive = isPositive;
        this.textSpeed = textSpeed;

        this.GetComponent<TextMesh>().text = setText();
        this.gameObject.AddComponent<BoxCollider2D>();
    }
	
	// Fixed Update for movement
	void FixedUpdate () {
        this.transform.position += new Vector3(textSpeed, 0, 0);
	}

    /// <summary>
    /// Randomly returns text out of the appropriate dictionary.
    /// </summary>
    private string setText()
    {
        switch(myLocation)
        {
            case TextState.Bar:
                return "test";

            case TextState.Car:
                return "test";

            case TextState.Office:
                return "test";

            default:
                return "test";
        }
    }
}
