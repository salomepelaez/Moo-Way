using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    public void Restart()
    {
        SceneManager.LoadScene("FirstLevel");
    }

}
