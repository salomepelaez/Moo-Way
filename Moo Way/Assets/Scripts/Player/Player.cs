using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 3.0f;

    public Joystick joystick;

    private Vector2 direction;

    public GameObject alien;

    private bool isCreated = false;

    void Update()
    {
        direction = joystick.Direction * speed * Time.deltaTime;
        transform.position += new Vector3(direction.x, direction.y, 0f);
        
        KeyboardMovement();
        LimitateAxis();
        AlienInstantiate();
    }

    void KeyboardMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
        }
    }

    private void LimitateAxis()
    {
        if (gameObject.transform.position.y >= 7.5f)
        {
            transform.position = new Vector3(transform.position.x, 7.5f, 0);
        }

        else if (gameObject.transform.position.y <= 0.3f)
        {
            transform.position = new Vector3(transform.position.x, 0.3f, 0);
        }

        else if (gameObject.transform.position.x <= -20f)
        {
            transform.position = new Vector3(-20f, transform.position.y, 0);
        }
    }

    void AlienInstantiate()
    {
        if (Input.GetKey(KeyCode.B) && isCreated == false)
        {
            GameObject a = Instantiate(alien, Vector3.zero, Quaternion.identity);
            isCreated = true;
            Vector3 pos = new Vector3();
            pos.x = -4.5f;
            pos.y = transform.position.y;
            pos.z = 0f;
            a.transform.position = pos;
        }
    }
}
