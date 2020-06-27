using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restarter : MonoBehaviour
{
    void Awake()
    {
        //PlayerPrefs.DeleteKey("restart");

        if(PlayerPrefs.HasKey("restart"))
        {

        }
        else
        {
            PlayerPrefs.SetInt("restart", 1);
            SceneManager.LoadScene("FirstLevel");
        }
    }
}
