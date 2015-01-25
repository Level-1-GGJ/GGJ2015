using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

public class PaperStack : MonoBehaviour
{
    /// <summary>
    /// yPos that the paper stack starts at.
    /// </summary>
    public float yStart = 20.0f;

    /// <summary>
    /// Velocity that the object is set to when it starts falling.
    /// </summary>
    public Vector2 initialFallingVelocity = new Vector2(0, -5.0f);

    /// <summary>
    /// Between 0 and 1.  High is faster.
    /// </summary>
    public float fadeSpeed = 0.1f;

    /// <summary>
    /// Whether the object is currently fading.
    /// </summary>
    public bool fade = false;

    /// <summary>
    /// The instruction this stack follows.
    /// </summary>
    public List<float> myInstructions;

    /// <summary>
    /// The current index the instruction is on.
    /// </summary>
    public int instructionIndex = 0;

    /// <summary>
    /// The time that has elapsed since the instruction was read.
    /// </summary>
    public float elapsedTime = 0;

    /// <summary>
    /// The time that needs to be reached in order to complete the next instruction.
    /// </summary>
    public float timeToWait = -1;

    /// <summary>
    /// The next action that will be taken by the paper stack.  False means the object needs to drop.  True means the object needs to fade and be reset.
    /// </summary>
    public bool actionState = true;

    /// <summary>
    /// Initializes the paper stack
    /// </summary>
    public void Initialize(string instructions)
    {
        myInstructions = new List<float>();

        // Split the string up to get the individual portions
        string[] splitInstructions = instructions.Split('|');
        foreach(string i in splitInstructions)
        {
            myInstructions.Add(float.Parse(i, CultureInfo.InvariantCulture));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Fades the object out of the scene
        if (fade && this.GetComponent<MeshRenderer>().material.color.a > 0)
        {
            this.GetComponent<MeshRenderer>().material.color = new Color(
                this.GetComponent<MeshRenderer>().material.color.r,
                this.GetComponent<MeshRenderer>().material.color.g,
                this.GetComponent<MeshRenderer>().material.color.b,
                this.GetComponent<MeshRenderer>().material.color.a - fadeSpeed);
        }
    }
    void Update()
    {
        // Add the time that's passed.
        elapsedTime += Time.deltaTime;
        // Check if the object is ready for its next instruction.
        if (elapsedTime > timeToWait)
        {
            // Reset the time back to zero, but account for innacuracies so we stay as on timer as possible.
            elapsedTime -= timeToWait;

            // Update the time to wait based on instructions.
            timeToWait = myInstructions[instructionIndex];

            // Move the instructions forward and make sure it loops.
            instructionIndex++;
            if (instructionIndex == myInstructions.Count)
                instructionIndex = 0;
            
            // If actionState is true, then we need to reset the object
            if (actionState)
            {
                // Enable fading
                fade = true;

                // The rest of the reset occurs after the fading finishes
                // Flip the switch
                actionState = false;
            }
            else // Begin to drop it again
            {
                // Make it opaque again
                this.GetComponent<MeshRenderer>().material.color = new Color(
                    this.GetComponent<MeshRenderer>().material.color.r,
                    this.GetComponent<MeshRenderer>().material.color.g,
                    this.GetComponent<MeshRenderer>().material.color.b,
                    1);

                // Ensure there's no fading.
                fade = false;

                // Drop the object
                this.rigidbody2D.isKinematic = false;
                this.rigidbody2D.velocity = initialFallingVelocity;

                // Flip the switch
                actionState = true;
            }
            
        }

        // If the fading is finished, then reset the object.
        if(fade && this.GetComponent<MeshRenderer>().material.color.a <= 0)
        {
            // Make SURE it's kinematic
            this.rigidbody2D.isKinematic = true;
            // Move it back to starting position
            this.transform.position = new Vector3(this.transform.position.x, yStart, this.transform.position.z);
            // Done fading
            fade = false;
            
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        this.rigidbody2D.isKinematic = true;
    }
}

