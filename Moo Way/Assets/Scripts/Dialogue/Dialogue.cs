using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI intro;
    public string[] phrases;
    int index;
    public GameObject button;

    public AudioSource okButton;

    Manager manager;

    private void Start()
    {
        manager = Manager.Instance;

        First();        
    }    

    public void First()
    {
        intro.text = phrases[0];
    }

    IEnumerator PrintMessages()
    {
        foreach (char p in phrases[index].ToCharArray())
        {
            intro.text += p;
        }

        yield return new WaitForSeconds(0.2f);
    }

    public void NextSentence()
    {
        okButton.Play();
        if(index < phrases.Length - 1)
        {
            index++;
            intro.text = "";

            StartCoroutine(PrintMessages());            
        }

        else
            intro.text = "";

        if (index == phrases.Length - 1)
        {
            button.SetActive(false);  
            intro.text = "";   
            manager.inGame = true; 
            Debug.Log(manager.inGame);                         
        }        
    }
}
