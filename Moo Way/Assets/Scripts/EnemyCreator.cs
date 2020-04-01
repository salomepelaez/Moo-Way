using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public GameObject p;

    void Start()
    {
        InvokeRepeating("CreateEnemies", 1f,20f);
    }

    void CreateEnemies()
    {
        GameObject police = Instantiate(p, Vector3.zero, Quaternion.identity);
        police.AddComponent<EnemyBehaviour>();
        police.AddComponent<BoxCollider2D>();
        police.GetComponent<BoxCollider2D>().isTrigger = true;

        Vector3 pos = new Vector3();
        pos.x = 7.9f;
        pos.y = 0.19f;
        pos.z = 0;
        police.transform.position = pos;
    }
}
