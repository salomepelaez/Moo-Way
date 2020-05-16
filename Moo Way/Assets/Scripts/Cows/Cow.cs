using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    private Transform target;
    private float distance;
   
    public static bool floating = false;

    private void Start()
    {
        target = FindObjectOfType<Player>().GetComponent<Transform>();
    }

    public void PickUpCow()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if(distance <= 3 && PlatformActivator.built == true)
        {
            floating = true;
        }
    }

    public void DropCow()
    {
        floating = false;
    }
}
