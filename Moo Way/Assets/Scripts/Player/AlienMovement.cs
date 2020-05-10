using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    private float speed = 3.0f;

    public Joystick joystick;

    private Vector2 direction;

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
        ChangeControl();
        Keyboard();
    }

    void ChangeControl()
    {
        if(alienControl == true)
        {
            direction = joystick.Direction * speed * Time.deltaTime;
            transform.position += new Vector3(direction.x, direction.y, 0f);
        }
    }

    void Keyboard()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed * Time.deltaTime;
            transform.localScale= new Vector2(0.22349f, 0.1635545f);
            anim.SetBool("walking", true);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed * Time.deltaTime;
            transform.localScale= new Vector2(-0.22349f, 0.1635545f);
            anim.SetBool("walking", true);
        }

        else if(Input.GetKey(KeyCode.J))
        {
            anim.SetBool("isAttacking", false);
            abducting = false;
        }

        else
        {
            anim.SetBool("walking", false);            
        }
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Cow")
        {
            anim.SetBool("isAttacking", true);
            abducting = true;
        }
    }
}
