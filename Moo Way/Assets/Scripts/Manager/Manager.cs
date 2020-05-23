using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public static bool inGame;

    public TextMeshProUGUI gameOver;

    public AudioSource music;
    public AudioSource loser;
    public AudioSource lose;

    public float timer;

    private Cow cow;

    void Start()
    {
        cow = GetComponent<Cow>();
        music.Play();
        inGame = true;

        InvokeRepeating("TimerCount", 1f, 1f);
    }

    void Update()
    {
        if(inGame == false)
            GameOver();

        Debug.Log(timer);
    }

    void GameOver()
    {
        gameOver.text = "You have been caught!";        
    }

    void TimerCount()
    {
        timer = timer + 1;        
    }

    public void StopTimer()
    {
        CancelInvoke("TimerCount");        
    }
}
