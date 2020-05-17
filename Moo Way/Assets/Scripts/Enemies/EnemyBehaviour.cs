using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    float distance;
    float enemySpeed = 3f;

    float timeLeft = 10.0f;

    Transform target;
    Rigidbody2D rb2d;

    private void Start()
    {
        target = FindObjectOfType<Player>().GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if(distance <= 5 && Manager.inGame == true)
        {
            GetTarget();
        }

        else
        {
            StopChasing();
        }

        Physics.IgnoreLayerCollision(9, 10, true);
        Physics.IgnoreLayerCollision(9, 9, true);
    }

    void GetTarget()
    {
        if(transform.position.x < target.position.x)
        {
            rb2d.velocity = new Vector2(enemySpeed, 0);
            transform.localScale= new Vector2(-0.3f, 0.3f);
        }

        else
        {
            rb2d.velocity = new Vector2(-enemySpeed, 0);
            transform.localScale= new Vector2(-0.3f, 0.3f);
        }

        InvokeRepeating("StartTimer", 1f, 1f);
    }

    void StopChasing()
    {
        rb2d.velocity = new Vector2(0, 0);
        transform.localScale= new Vector2(0.3f, 0.3f);
    }

    void StartTimer()
    {
        if(IddleBehaviour.timer == true)
        {    
            timeLeft -= Time.deltaTime;

                if(timeLeft < 0)
                {
                    Manager.inGame = false;
                }
        }

        else 
            timeLeft = 10.0f;
    }
}
