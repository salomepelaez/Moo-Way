using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 3.0f;

    void Update()
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
}
