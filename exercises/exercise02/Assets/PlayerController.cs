using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // At the top of a component you can create variables that can be referenced
    // throughout the entire component. When you write "public" infront of the
    // variable declaration it makes it so you can edit the value of the variable
    // from the Unity inspector.
    public float speed = 0.001f;
    public float launchForce = 100;

    float rotateSpeed = 0.1f;

    // This variable will hold a reference to the rigid body component. You give
    // variable its value by dragging and dropping the component into the
    // inspector inside of Unity.
    public Rigidbody rb;

    float lastRotateDirectionSwitchTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // The following if statement demonstrates how to implement a "timer"
        // pattern. Time.time is the amount of time in seconds since the game
        // started. By subtracting thevariable "lastRotateDirectionSwitchTime"
        // from the current time since the game started, we can find out how long
        // it has been since we last multiplied "rotateSpeed" by -1. This sort of
        // programming technique can be called the "timer pattern" and it is
        // useful in situations where you want code to run at some interval.
        if (Time.time - lastRotateDirectionSwitchTime > 1f)
        {
            rotateSpeed = rotateSpeed * -1;
            lastRotateDirectionSwitchTime = Time.time;
        }
        gameObject.transform.Rotate(0, rotateSpeed, 0);

        // Check to see if the Spacebar was just pressed. If so, tell the rigidbody
        // component to launch forward at a given speed (launchForce).
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.useGravity = true;
            rb.AddForce(gameObject.transform.forward * launchForce);
        }

        // Below is a commented out example of how to move something forward:
        // gameObject.transform.Translate(gameObject.transform.forward * speed);
    }

    // Unity will call the "OnCollisionEnter" function whenever something collides
    // with the gameObject. The "col" variable will contain information about the
    // game object that was collided with.
    //
    // In this example, we check to see if we collided with the game object named
    // "TargetCube" and if so, we change its color.
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "TargetCube")
        {
            col.gameObject.GetComponent<Renderer>().material.color = Color.red;

            // If you wanted to remove the cube rather than change its color, you
            // would "Destroy" it using the following line of code.
            //Destroy(col.gameObject);
        }
    }
}
