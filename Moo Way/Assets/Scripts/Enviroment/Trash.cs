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
            StartCoroutine("Recycle");
            Debug.Log(manager.fuel);
        }
    }

    IEnumerator Recycle()
    {
        manager.fuel = manager.fuel + 5;

        yield return new WaitForSeconds(5);
    }
}
