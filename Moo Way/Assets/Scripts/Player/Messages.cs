using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Messages : MonoBehaviour
{
    public TextMeshProUGUI message;
    private bool held = false;

    private void Awake()
    {
        Intialize();
    }

    private void Intialize()
    {
        message = GameObject.Find("cow_message").GetComponent<TextMeshProUGUI>();
    }
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.tag == "Cow" && held == false)
        {
            message.text = "Press Y to pick up the cow";

            if (Input.GetKeyDown(KeyCode.Y))
            {
                message.text = "";
                held = true;
            }
        }

        else if(held == true)
             message.text = "";
    }    

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Cow")
        {
            message.text = "";
        }
    }
}
