using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public float speed = 0.001f;
    public float launchForce = 100;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < -1.48 ||
        gameObject.transform.position.x > 2.16)
        {
            speed = speed * -1;
        }
        gameObject.transform.Translate(speed, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.useGravity = true;
        }


    }
}