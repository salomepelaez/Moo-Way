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

    void Start()
    {
        music.Play();
        inGame = true;
    }

    void Update()
    {
        if(inGame == false)
            GameOver();
    }

    void GameOver()
    {
        gameOver.text = "You have been caught!";        
    }
}
