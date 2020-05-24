using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using TMPro;

public class Manager : MonoBehaviour
{
    public static bool inGame;
    public bool dead;

    public TextMeshProUGUI gameOver;

    public AudioSource music;
    public AudioSource loser;
    public AudioSource lose;

    public float timer;

    private Cow cow;
    private EnemyBehaviour enemy;

    public void Awake()
    {
        cow = GetComponent<Cow>();
        enemy = GetComponent<EnemyBehaviour>();
        music.Play();
        inGame = true;
        dead = false;

        InvokeRepeating("TimerCount", 1f, 1f);
    }

    void Update()
    {
        GameOver();
        Debug.Log(timer);
    }

    public void GameOver()
    {         
        if(dead == true)
        {
            inGame = false;
            gameOver.text = "You have been caught!"; 

            StopTimer(); 
        }     
    }

    public void TimerCount()
    {
        timer = timer + 1;  

        if(timer > 240)
        {
            gameOver.text = "You ran out of time!";
            inGame = false;
            Analytics.CustomEvent("Death", new Dictionary<string, object>
            {
                { "Death", "by running out of time" },
            });
        }      
    }

    public void StopTimer()
    {
        CancelInvoke("TimerCount");        
    }
}
