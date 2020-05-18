using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public AudioSource menu;
    public AudioSource restartButton;
    public AudioSource startLevel;

    public void BackToMenu()
    {
        menu.Play();
        SceneManager.LoadScene("Menu");
    }

    public void StartGame()
    {
        startLevel.Play();
        SceneManager.LoadScene("FirstLevel");
    }

    public void Restart()
    {
        restartButton.Play();
        SceneManager.LoadScene("FirstLevel");
    }

}
