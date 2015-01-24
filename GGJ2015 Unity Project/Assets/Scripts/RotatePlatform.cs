using UnityEngine;
using System.Collections;

public class RotatePlatform : MonoBehaviour
{
    public float startAngle = 0;
    public float endAngle = 360;
    public float rotationSpeed;
    public bool isLooping = true;
    public bool goForward = true;

    // Update is called once per frame
    void FixedUpdate()
    {

        if (goForward)
        {
            this.rigidbody2D.rotation = this.rigidbody2D.rotation + rotationSpeed;

            if (this.rigidbody2D.rotation > endAngle)
            {
                if (isLooping)
                {
                    this.rigidbody2D.rotation = startAngle;
                }
                else
                {
                    goForward = false;
                }
            }
        }
        else
        {
            this.rigidbody2D.rotation = this.rigidbody2D.rotation - rotationSpeed;

            if (this.rigidbody2D.rotation <= startAngle)
            {
                if (isLooping)
                {
                    this.rigidbody2D.rotation = endAngle;
                }
                else
                {
                    goForward = true;
                }
            }
        }
    }
}
