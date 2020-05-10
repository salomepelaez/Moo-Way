using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinemachineScript : MonoBehaviour
{
    public GameObject alienCamera;

    void Awake()
    {
        alienCamera.SetActive(false);
    }

    void Update()
    {
        ChangePlayerCamera();
    }
    void ChangePlayerCamera()
    {
        if(AlienMovement.alienControl == true)
        {
            alienCamera.SetActive(true);
        }

        else if(AlienMovement.alienControl == false)
        {
            alienCamera.SetActive(false);
        }
    }
}
