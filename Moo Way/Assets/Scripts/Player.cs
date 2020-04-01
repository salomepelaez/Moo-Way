using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 3.0f;

    public Joystick joystick;

    private Vector2 direction;

    public static float held;

    void Update()
    {
        direction = joystick.Direction * speed * Time.deltaTime;
        transform.position += new Vector3(direction.x, direction.y, 0f);
        
        KeyboardMovement();
    }

    void KeyboardMovement()
    {
        if (Input.GetKey(KeyCode.W) && gameObject.transform.position.y <= 4.1)
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D) && gameObject.transform.position.x <= 8)
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A) && gameObject.transform.position.x >= -8)
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Cow")
        {
            
        }
    }
}
