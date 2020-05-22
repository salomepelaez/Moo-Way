using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class DeathEventManager : MonoBehaviour
{
    public int cop;
    
    void Update()
    {
        GameOver();
    }

    void GameOver()
    {
        if(Manager.inGame == false)
        {
            Analytics.CustomEvent("Death", new Dictionary<string, object>
            {
                { "Police", cop },
            });
        }
    }
}
