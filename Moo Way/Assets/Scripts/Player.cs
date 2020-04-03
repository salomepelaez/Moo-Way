using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 3.0f;

    public Joystick joystick;

    private Vector2 direction;

    void Update()
    {
        direction = joystick.Direction * speed * Time.deltaTime;
        transform.position += new Vector3(direction.x, direction.y, 0f);
        
        KeyboardMovement();
        LimitateAxis();
    }

    void KeyboardMovement()
    {
        if (Input.GetKey(KeyCode.W) && gameObject.transform.position.y <= 4f)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D) && gameObject.transform.position.x <= 8f)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A) && gameObject.transform.position.x >= -8f)
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
    }

    private void LimitateAxis()
    {
        if (gameObject.transform.position.y >= 4f)
        {
            transform.position = new Vector3(transform.position.x, 4f, 0);
        }

        else if (gameObject.transform.position.y <= 0.3f)
        {
            transform.position = new Vector3(transform.position.x, -0.3f, 0);
        }

        else if (gameObject.transform.position.x <= -18f)
        {
            transform.position = new Vector3(-18f, transform.position.y, transform.position.z);
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Cow")
        {
            
        }
    }*/
}
