using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cow : MonoBehaviour
{
    private Transform target;
    private float distance;
   
    public static bool floating = false;

    private int counter = 0;

    public TextMeshProUGUI winner;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Platform")
        {
            Destroy(this.gameObject);
            counter = counter + 1;
            Debug.Log(counter);

            if(counter == 3)
            {
                winner.text = "Well done!";                
            }
        }
    }
}
