using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlatformActivator : MonoBehaviour
{
    public TextMeshProUGUI activate;
    public GameObject platform;
    public GameObject button;
    private bool canBuild;
    public static bool built;

    public AudioSource platformSound;
    
    void Awake()
    {
        button.SetActive(false);
    }

    void Start()
    {
        canBuild = false;
        built = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator" && built == false)
        {
            activate.text = "Press the button to build the teletransportation platform";
            button.SetActive(true);
            canBuild = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator" || built == true)
        {
            activate.text = "";
            button.SetActive(false);
            canBuild = false;            
        }
    }

    public void ActivatePlatform()
    {        
        if(canBuild == true && built == false)
        {
            platformSound.Play();
            GameObject p = Instantiate(platform, Vector3.zero, Quaternion.identity);
            Vector3 pos = new Vector3();
            pos.x = -9.4f;
            pos.y = -0.6f;
            pos.z = 0;
            p.transform.position = pos;

            built = true;
        }
    }
}
