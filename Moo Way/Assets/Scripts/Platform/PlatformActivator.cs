using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlatformActivator : MonoBehaviour
{
    public TextMeshProUGUI activate;
    public GameObject platform;
    public GameObject button;
    private bool canBuild = false;
    
    void Start()
    {
        button.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            activate.text = "Press the button to build the teletransportation platform";
            button.SetActive(true);
            canBuild = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            activate.text = "";
            button.SetActive(false);
            canBuild = false;            
        }
    }

    public void ActivatePlatform()
    {
        if(canBuild == true)
        {
            GameObject p = Instantiate(platform, Vector3.zero, Quaternion.identity);
            Vector3 pos = new Vector3();
            pos.x = 137.32f;
            pos.y = -0.6f;
            pos.z = 0;
            p.transform.position = pos;
        }
    }
}
