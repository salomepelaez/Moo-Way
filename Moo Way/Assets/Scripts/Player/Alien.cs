using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{
    public GameObject alien;

    private Transform player;

    public AudioSource create;
    public AudioSource goBack;

    Manager manager;
    
    void Awake()
    {
        manager = Manager.Instance;
    }

    void Start()
    {
        alien.SetActive(false);
        player = FindObjectOfType<Player>().GetComponent<Transform>();

        manager.isCreated = false;
    }

    void Update()
    {
        if(manager.getOut == true)
        {
            manager.getOut = false;
            alien.SetActive(true);
                                    
            Vector3 pos = new Vector3();
            pos.x = player.position.x;
            pos.y = 0.3f;
            pos.z = 0f;
            alien.transform.position = pos;

            manager.isCreated = true; 
            manager.alienControl = true;  
        }
    }

    public void AlienInstantiate()
    {
        if (manager.isCreated == false && manager.canWalk == true && manager.inGame == true)
        {
            alien.SetActive(true);
                            
            manager.isCreated = true; 

            manager.alienControl = true;    

            Vector3 pos = new Vector3();
            pos.x = player.position.x;
            pos.y = -0.3f;
            pos.z = 0f;
            alien.transform.position = pos;

            create.Play();       
        }  
    }

    public void GoBack()
    {
        if(manager.isCreated == true && manager.inGame == true)
        {      
            goBack.Play();      
            manager.isCreated = false;
            manager.canWalk = false;
            manager.alienControl = false;  
            alien.SetActive(false);
        }    
    }
}
