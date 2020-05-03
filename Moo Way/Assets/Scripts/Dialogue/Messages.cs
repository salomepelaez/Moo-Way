using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Messages : MonoBehaviour
{
    public TextMeshProUGUI continueB;

    public GameObject continueButton;

    private void Awake()
    {
        continueB = GameObject.Find("ContinueB").GetComponent<TextMeshProUGUI>();
    }

    public void Continue()
    {
        continueB.text = "";
        continueButton.SetActive(false);
    }
}
