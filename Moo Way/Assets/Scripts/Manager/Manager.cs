using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public static bool inGame;

    public TextMeshProUGUI gameOver;

    void Start()
    {
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
            gameOver.text = "You have been caught!";
        }
    }
}
