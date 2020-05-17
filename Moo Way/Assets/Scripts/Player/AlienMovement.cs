using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    private float speed = 3.0f;

    public Joystick joystick;

    private float direction;

    public static bool alienControl = false;
    public static bool abducting = false;

    private Animator anim;

    public GameObject alien;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(alienControl == true  && Manager.inGame == true)
        {
            direction = joystick.Horizontal * speed * Time.deltaTime;
            transform.position += new Vector3(direction, 0f, 0f);

            if(direction > 0.01f)
            {
                anim.SetBool("walking", true);
                transform.localScale= new Vector2(0.22349f, 0.1635545f);
            }

            else if(direction < -0.01f)
            {
                anim.SetBool("walking", true);
                transform.localScale= new Vector2(-0.22349f, 0.1635545f);
            }

            else
            {
                anim.SetBool("walking", false);            
            }

            Debug.Log(direction);
        }
    }
}
