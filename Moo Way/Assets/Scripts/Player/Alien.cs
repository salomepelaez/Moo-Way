using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public GameObject alien;

    public static bool isCreated;

    private Transform player;

    public AudioSource create;
    public AudioSource goBack;

    void Start()
    {
        alien.SetActive(false);
        player = FindObjectOfType<Player>().GetComponent<Transform>();

        isCreated = false;
    }

    void Update()
    {
        if(Player.getOut == true)
        {
            Player.getOut = false;
            alien.SetActive(true);
                                    
            Vector3 pos = new Vector3();
            pos.x = player.position.x;
            pos.y = 0.3f;
            pos.z = 0f;
            alien.transform.position = pos;

            isCreated = true; 
            AlienMovement.alienControl = true;  
        }
    }

    public void AlienInstantiate()
    {
        if (isCreated == false && Player.canWalk == true && Manager.inGame == true)
        {
            create.Play();
            alien.SetActive(true);
                                    
            Vector3 pos = new Vector3();
            pos.x = player.position.x;
            pos.y = -0.3f;
            pos.z = 0f;
            alien.transform.position = pos;

            isCreated = true; 
            AlienMovement.alienControl = true;           
        }  
    }

    public void GoBack()
    {
        if(isCreated == true && Manager.inGame == true)
        {      
            goBack.Play();      
            isCreated = false;
            Player.canWalk = false;
            AlienMovement.alienControl = false;  
            alien.SetActive(false);
        }    
    }
}
