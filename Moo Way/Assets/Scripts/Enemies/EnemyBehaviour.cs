using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class EnemyBehaviour : MonoBehaviour
{
    float distance;
    float enemySpeed;
    float timeLeft;

    Transform target;
    Rigidbody2D rb2d;

    public AudioSource police;
    public int cop;

    private void Start()
    {
        target = FindObjectOfType<Player>().GetComponent<Transform>();
        rb2d = GetComponent<Rigidbody2D>();

        enemySpeed = 3f;
        timeLeft = 10.0f;
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
            police.Play();  
            timeLeft -= Time.deltaTime;

                if(timeLeft < 0)
                {
                    Manager.inGame = false;
                    Analytics.CustomEvent("Death", new Dictionary<string, object>
                    {
                        { "Police", cop },
                    });
                }
        }

        else 
            timeLeft = 10.0f;
    }
}
