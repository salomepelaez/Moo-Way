using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinemachineScript : MonoBehaviour
{
    public GameObject alienCamera;
    Manager manager;

    void Awake()
    {
        manager = Manager.Instance;
        alienCamera.SetActive(false);
    }

    void Update()
    {
        ChangePlayerCamera();
    }
    
    void ChangePlayerCamera()
    {
        if(manager.alienControl == true)
        {
            alienCamera.SetActive(true);
        }

        else if(manager.alienControl == false)
        {
            alienCamera.SetActive(false);
        }
    }
}
