using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Messages : MonoBehaviour
{
    public TextMeshProUGUI message;

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
        if (other.transform.tag == "Cow")
        {
            message.text = "Press Y to pick up the cow";

            if (Input.GetKeyDown(KeyCode.Y))
            {
                message.text = "Press X to drop the cow";
            }
        }
    }    

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Cow")
        {
            message.text = "";
        }
    }
}
