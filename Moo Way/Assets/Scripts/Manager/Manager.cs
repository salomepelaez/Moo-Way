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

    void Start()
    {
        music.Play();
        inGame = true;
    }

    void Update()
    {
        GameOver();
    }

    void GameOver()
    {
        if(inGame == false)
        { 
            music.Stop();
            gameOver.text = "You have been caught!";
            loser.Play();
        }
    }
}
