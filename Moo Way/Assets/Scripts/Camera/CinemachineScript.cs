using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinemachineScript : MonoBehaviour
{
    public GameObject virtualCamera1;
    public GameObject virtualCamera2;
    public GameObject virtualCamera3;

    void Awake()
    {
        virtualCamera1.SetActive(false);
        virtualCamera2.SetActive(false);
        virtualCamera3.SetActive(false);
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
}
