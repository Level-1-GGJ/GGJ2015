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
/// Created by Luna Meier and Samuel Sternklar
/// </summary>
[RequireComponent(typeof(TextMesh))]
[RequireComponent(typeof(MovementController))]
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
    /// Determines whether the thought is positive or negative
    /// </summary>
    public bool isPositive;

    /// <summary>
    /// The direction that this object is travelling in
    /// </summary>
    public Vector2 direction;

    /// <summary>
    /// The movement controller on this object
    /// </summary>
    MovementController mc;

    //Start function
    public void Start()
    {
        mc = GetComponent<MovementController>();
        mc.IsKinematic = true;
        this.GetComponent<TextMesh>().text = setText();
        gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
        Destroy(gameObject, 3f);
    }

    /// <summary>
    /// Initializes the text box.
    /// </summary>
    /// <param name="myLocation">The location the thought is being spawned.</param>
    /// <param name="textSpeed">Tracks the speed at which the text moves each fixedUpdate.  Negative moves left.</param>
    public void Initialize(TextState myLocation, Vector2 direction, bool isPositive)
    {
        this.direction = direction.normalized;

        if (direction != Vector2.zero)
        {
            if (direction.x < 0)
            {
                direction *= -1;
            }
            transform.right = direction;
        }

        this.myLocation = myLocation;
        this.isPositive = isPositive;
    }
	
	// Fixed Update for movement
	void FixedUpdate () {
        mc.Move(direction * textSpeed);
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

    public void OnTriggerEnter2D(Collider2D col)
    {
        RandomText text;
        if ((text = col.GetComponent<RandomText>()) && text.isPositive != isPositive)
        {
            Destroy(gameObject);
        }
    }
}
