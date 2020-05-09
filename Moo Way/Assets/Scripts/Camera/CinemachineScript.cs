using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinemachineScript : MonoBehaviour
{
    public GameObject virtualCamera1;
    public GameObject virtualCamera2;
    public GameObject virtualCamera3;
    public GameObject alienCamera;

    void Awake()
    {
        virtualCamera1.SetActive(false);
        virtualCamera2.SetActive(false);
        virtualCamera3.SetActive(false);
        alienCamera.SetActive(false);
    }

    void Update()
    {
        ChangePlayerCamera();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Collider1")
        {
            virtualCamera1.SetActive(true);
        }        

        if(other.tag == "Collider2")
        {
            virtualCamera2.SetActive(true);
        }   

        if(other.tag == "Collider3")
        {
            virtualCamera3.SetActive(true);
        }   
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Collider1")
        {
            virtualCamera1.SetActive(false);
        }  

        if(other.tag == "Collider2")
        {
            virtualCamera2.SetActive(false);
        }   

        if(other.tag == "Collider3")
        {
            virtualCamera3.SetActive(false);
        }       
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
