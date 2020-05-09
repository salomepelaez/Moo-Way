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
        alien.SetActive(false);
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
            alien.SetActive(true);
                                    
            Vector3 pos = new Vector3();
            pos.x = player.position.x;
            pos.y = -0.3f;
            pos.z = 0f;
            alien.transform.position = pos;

            isCreated = true;            
        }  

        else if (Input.GetKey(KeyCode.C) && isCreated == true)
        {            
            isCreated = false;
            alien.SetActive(false);
        }     
    }
}
