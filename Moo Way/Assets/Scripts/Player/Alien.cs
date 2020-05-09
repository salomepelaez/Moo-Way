using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public GameObject alien;

    private bool isCreated = false;

    private Transform player;

    void Start()
    {
        player = FindObjectOfType<Player>().GetComponent<Transform>();
    }

    void Update()
    {
        AlienInstantiate();
    }

    void AlienInstantiate()
    {
        if (Input.GetKey(KeyCode.B) && isCreated == false)
        {
            isCreated = true;
            GameObject a = Instantiate(alien, Vector3.zero, Quaternion.identity);            
            Vector3 pos = new Vector3();
            pos.x = player.position.x;
            pos.y = -0.3f;
            pos.z = 0f;
            a.transform.position = pos;

            if (Input.GetKey(KeyCode.C) && isCreated == true)
            {            
                isCreated = false;
                Destroy(this.gameObject);
            }
        }       
    }
}
