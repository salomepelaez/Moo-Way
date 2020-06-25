using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    Manager manager;
    
    void Start()
    {
        manager = Manager.Instance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<AlienMovement>() != null)
        {    
            manager.fuel = manager.fuel + 10;

            if(manager.fuel >= 45)
            {
                manager.fuel = 45;
            }     
            
            this.gameObject.SetActive(false);

            Debug.Log("+10" + manager.fuel);
        }
    }

    void RecycleEnergy()
    {
        manager.fuel = manager.fuel + 3;

        if(manager.fuel >= 45)
        {
            manager.fuel = 45;
        }        
    }
}
