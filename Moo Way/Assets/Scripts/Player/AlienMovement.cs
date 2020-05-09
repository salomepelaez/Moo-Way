using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    private float speed = 3.0f;

    public Joystick joystick;

    private Vector2 direction;
    
    public static bool alienControl = false;

    void Update()
    {
        ChangeControl();   
    }

    void ChangeControl()
    {
        if(alienControl == true)
        {
            direction = joystick.Direction * speed * Time.deltaTime;
            transform.position += new Vector3(direction.x, direction.y, 0f);
        }
    }
}
