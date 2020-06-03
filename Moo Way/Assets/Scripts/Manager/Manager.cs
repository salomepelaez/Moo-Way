using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using TMPro;

public class Manager : MonoBehaviour
{
    public static bool inGame;
    public bool dead;
    public bool seen;

    public TextMeshProUGUI gameOver;
    public TextMeshProUGUI timerText;

    public AudioSource music;
    public AudioSource loser;
    public AudioSource lose;

    public float timer;
    private int seconds;
    private int minutes;
    private string timerString;

    private Cow cow;
    private EnemyBehaviour enemy;

    public void Awake()
    {
        cow = GetComponent<Cow>();
        enemy = GetComponent<EnemyBehaviour>();
        inGame = true;
        dead = false;
        seen = false;
        timer = 300f;        
    }

    void Start()
    {
        music.Play();
        InvokeRepeating("TimerCount", 1f, 1f);
    }

    void Update()
    {
        GameOver();
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
        timer = timer - 1;  
        seconds = (int)(timer % 60);
        minutes = (int)(timer / 60) % 60;

        timerString = string.Format("{0:0}:{1:0}", minutes, seconds);
        timerText.text = timerString;

        if(timer < 0)
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
