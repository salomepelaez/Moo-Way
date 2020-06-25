using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    Manager manager;
    
    void Awake()
    {
        manager = Manager.Instance;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<AlienMovement>() != null)
        {
            InvokeRepeating("RecycleEnergy", 1f, 2f);
           // Debug.Log(manager.fuel);
        }
    }

    void RecycleEnergy()
    {
        manager.fuel = manager.fuel + 5;

        if(manager.fuel >= 45)
        {
            manager.fuel = 45;
        }
    }
}
