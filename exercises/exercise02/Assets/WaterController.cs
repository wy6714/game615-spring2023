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
        //move water x position within groud x arrange
        //(-1.48,2.16)
        if (gameObject.transform.position.x < -1.8 ||
        gameObject.transform.position.x > 2.6)
        {
            speed = speed * -1;
        }
        gameObject.transform.Translate(speed, 0, 0);

        //press space, check gravity -> water fall
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.useGravity = true;
        }


    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Ground")
        {
            col.gameObject.GetComponent<Renderer>().material.color = new Color(0.3411f, 0.2431f, 0.09411f, 1f);
            //col.gameObject.GetComponent<Renderer>().material.color = new Color(0.3604f, 0.7259f, 0.9433f, 1f);

            Destroy(gameObject);
        }
    }
}