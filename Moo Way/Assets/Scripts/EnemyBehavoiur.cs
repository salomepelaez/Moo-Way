using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavoiur : MonoBehaviour
{
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
        GetTarget();
    }

    public void GetTarget()
    {
        /*direction = new Vector2(target.transform.position.x - transform.position.x, -0.04f);
        transform.position = direction * enemySpeed * Time.deltaTime;*/

        if(transform.position.x < target.position.x)
        {
            rb2d.velocity = new Vector2(enemySpeed, 0);
            //transform.localScale= new Vector2(1, 1);
        }

        else
        {
            rb2d.velocity = new Vector2(-enemySpeed, 0);
            //transform.localScale= new Vector2(-1, 1);
        }

    }
}
