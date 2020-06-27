using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    private float speed = 3.0f;

    public Joystick joystick;

    private float direction;
   
    private Animator anim;

    public GameObject alien;

    Manager manager;

    void Start()
    {
        manager = Manager.Instance;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(manager.alienControl == true  && manager.inGame == true)
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
        }

        LimitateAxis();

        Physics2D.IgnoreLayerCollision(10, 11, true);
        Physics2D.IgnoreLayerCollision(11, 10, true);
    }

    private void LimitateAxis()
    {
        if (gameObject.transform.position.x <= -20f)
        {
            transform.position = new Vector3(-20f, transform.position.y, 0);
        }

        else if (gameObject.transform.position.x <= -163f)
        {
            transform.position = new Vector3(-163f, transform.position.y, 0);
        }
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<EnemyBehaviour>() != null)
        {
            Debug.Log("aaa");
        }
    }*/
}
