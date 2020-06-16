﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using TMPro;

public class Cow : MonoBehaviour
{
    private Transform target;
    private float distance;
   
    public static bool floating;
    public bool won;

    public static int counter;

    public TextMeshProUGUI winner;

    public AudioSource cow;

    Manager manager;
    GameObject man;

    private void Awake()
    {
        target = FindObjectOfType<Player>().GetComponent<Transform>();
        counter = 0;
        floating = false;
        won = false;
        manager = Manager.Instance;
    }

    public void PickUpCow()
    {
        distance = Vector2.Distance(transform.position, target.position);

        if(distance <= 3 && manager.built == true)
        {
            floating = true;
        }
    }

    public void DropCow()
    {
        floating = false;
        cow.Play();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Platform")
        {
            cow.Play();
            Destroy(this.gameObject);
            counter = counter + 1;
            Debug.Log(counter);

            if(counter == 3)
            {
                winner.text = "Well done!";   
                manager.StopTimer(); 
                Analytics.CustomEvent("Winner");      
            }
        }
    }

    
}
