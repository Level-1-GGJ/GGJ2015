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

        this.GetComponent<TextMesh>().text = SetText().ToUpper();
        gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
    }
	
	// Fixed Update for movement
	void FixedUpdate () {
        mc.Move(direction * textSpeed);
	}

    /// <summary>
    /// Randomly returns text out of the appropriate dictionary.
    /// </summary>
    private string SetText()
    {
        // Happy text
        if(isPositive)
        {
            switch(Application.loadedLevel - 1)
            {
                case 0:
                    return TextDictionary.generalHappy0[Random.Range(0, TextDictionary.generalHappy0.Count)];
                case 1:
                    return TextDictionary.generalHappy1[Random.Range(0, TextDictionary.generalHappy1.Count)];
                case 2:
                    return TextDictionary.generalHappy2[Random.Range(0, TextDictionary.generalHappy2.Count)];
                case 3:
                    return TextDictionary.generalHappy3[Random.Range(0, TextDictionary.generalHappy3.Count)];
            }
        }

        // The rest of this text is negative
        switch (Application.loadedLevel - 1)
        {
            case 0:
                switch(myLocation)
                {
                    case TextState.Office:
                        return TextDictionary.jobNegative0[Random.Range(0, TextDictionary.jobNegative0.Count)];
                    default:
                        return TextDictionary.generalNegative0[Random.Range(0, TextDictionary.generalNegative0.Count)];
                } 

            case 1:
                switch (myLocation)
                {
                    case TextState.Office:
                        return TextDictionary.jobNegative1[Random.Range(0, TextDictionary.jobNegative1.Count)];
                    default:
                        return TextDictionary.generalNegative1[Random.Range(0, TextDictionary.generalNegative1.Count)];
                }

            case 2:
                switch (myLocation)
                {
                    case TextState.Office:
                        return TextDictionary.jobNegative2[Random.Range(0, TextDictionary.jobNegative2.Count)];
                    case TextState.Car:
                        return TextDictionary.carNegative2[Random.Range(0, TextDictionary.carNegative2.Count)];
                    default:
                        return TextDictionary.generalNegative2[Random.Range(0, TextDictionary.generalNegative2.Count)];
                }

            case 3:
                switch (myLocation)
                {
                    case TextState.Office:
                        return TextDictionary.jobNegative3[Random.Range(0, TextDictionary.jobNegative3.Count)];
                    case TextState.Car:
                        return TextDictionary.carNegative3[Random.Range(0, TextDictionary.carNegative3.Count)];
                    case TextState.Bar:
                        return TextDictionary.barNegative3[Random.Range(0, TextDictionary.barNegative3.Count)];
                    default:
                        return TextDictionary.generalNegative3[Random.Range(0, TextDictionary.generalNegative3.Count)];
                }
            case 4:
                switch (myLocation)
                {
                    case TextState.Office:
                        return TextDictionary.jobNegative4[Random.Range(0, TextDictionary.jobNegative4.Count)];
                    case TextState.Car:
                        return TextDictionary.carNegative4[Random.Range(0, TextDictionary.carNegative4.Count)];
                    case TextState.Bar:
                        return TextDictionary.barNegative4[Random.Range(0, TextDictionary.barNegative4.Count)];
                    default:
                        return TextDictionary.generalNegative4[Random.Range(0, TextDictionary.generalNegative4.Count)];
                }
            case 5:
                switch (myLocation)
                {
                    case TextState.Office:
                        return TextDictionary.jobNegative5[Random.Range(0, TextDictionary.jobNegative5.Count)];
                    case TextState.Car:
                        return TextDictionary.carNegative5[Random.Range(0, TextDictionary.carNegative5.Count)];
                    case TextState.Bar:
                        return TextDictionary.barNegative5[Random.Range(0, TextDictionary.barNegative5.Count)];
                    default:
                        return TextDictionary.generalNegative5[Random.Range(0, TextDictionary.generalNegative5.Count)];
                }
            case 6:
                return TextDictionary.generalNegative6[Random.Range(0, TextDictionary.generalNegative6.Count)];
            default:
                return "ERROR";
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
