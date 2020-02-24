using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavoiur : MonoBehaviour
{
    float enemySpeed = 3f;
    Vector3 direction;
    Transform target;

    private void Start()
    {
        target = FindObjectOfType<Player>().GetComponent<Transform>();
    }

    void Update()
    {
        GetTarget();
    }

    public void GetTarget()
    {
        direction = Vector3.Normalize(target.transform.position - transform.position);
        transform.position += direction * enemySpeed * Time.deltaTime;
    }
}
