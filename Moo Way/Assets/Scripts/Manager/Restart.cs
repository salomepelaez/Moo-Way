using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Awake()
    {
        //PlayerPrefs.DeleteKey("reinicio");

        if(PlayerPrefs.HasKey("reinicio"))
        {

        }
        else
        {
            PlayerPrefs.SetInt("reinicio", 1);
            SceneManager.LoadScene("FirstLevel");
        }
    }
}
