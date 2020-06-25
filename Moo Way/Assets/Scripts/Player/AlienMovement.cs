using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    private float speed = 3.0f;

    public Joystick joystick;

    private float direction;

    public static bool alienControl;
    public static bool abducting;

    private Animator anim;

    public GameObject alien;

    Manager manager;

    void Awake()
    {
        manager = Manager.Instance;
        anim = GetComponent<Animator>();

        alienControl = false;
        abducting = false;
    }

    void Update()
    {
        if(alienControl == true  && manager.inGame == true)
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

        Physics.IgnoreLayerCollision(10, 11, true);

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
