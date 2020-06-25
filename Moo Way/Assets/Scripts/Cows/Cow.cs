using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using TMPro;

public class Cow : MonoBehaviour
{
    private Transform target;
    private float distance;
   
    public bool won;

    public TextMeshProUGUI winner;

    public AudioSource cow;

    Manager manager;
    
    private void Awake()
    {
        target = FindObjectOfType<Player>().GetComponent<Transform>();        
        won = false;
        manager = Manager.Instance;
        manager.cowCounter = 0;
        manager.floating = false;
    }

    public void PickUpCow()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if(distance <= 3 && manager.built == true)
        {
            manager.floating = true;
        }
    }

    public void DropCow()
    {
        manager.floating = false;
        cow.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Platform")
        {
            cow.Play();
            Destroy(this.gameObject);
            manager.cowCounter = manager.cowCounter + 1;

            if(manager.cowCounter == 3 && manager.cowsCollected == false)
            {
                StartCoroutine("EscapeText");
                manager.StopTimer(); 
                manager.cowsCollected = true;

                Analytics.CustomEvent("All items collected");      
            }
        }
    }

    IEnumerator EscapeText()
    {
        winner.text = "Now escape from the police!"; 
        yield return new WaitForSeconds(4);
        winner.text = ""; 
    }
}
