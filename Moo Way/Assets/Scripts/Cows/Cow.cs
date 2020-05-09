using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    private Animator anim;
    private Transform alien;

    private float speed = 1f;
    private Rigidbody2D rb;

    void Awake()
    {
        transform.tag = "Cow";
        alien = FindObjectOfType<AlienMovement>().GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        InvokeRepeating("FloatingCow", 3f, 2f);
    }    

    void FloatingCow()
    {
        if(AlienMovement.abducting == true)
        {
            anim.SetBool("isFloating", true);
            transform.position = Vector2.MoveTowards(transform.position, alien.position, speed * Time.deltaTime);
        }

        else if(AlienMovement.abducting == false)
       {
           anim.SetBool("isFloating", false);
           anim.SetBool("isIddle", true);
           rb.gravityScale = 1;
       }
    }
}
