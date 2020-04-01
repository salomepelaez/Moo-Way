using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    float distance;
    float enemySpeed = 3f;
    Vector2 direction;
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

        if(distance >= 5)
        {
            GetTarget();
        }

        else
        {
            StopChasing();
        }

        Debug.Log(distance);
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
            transform.localScale= new Vector2(0.3f, 0.3f);
        }

    }

    void StopChasing()
    {
        rb2d.velocity = new Vector2(0, 0);
        transform.localScale= new Vector2(-0.3f, 0.3f);
    }
}
