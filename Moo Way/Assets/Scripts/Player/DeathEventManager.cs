using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class DeathEventManager : MonoBehaviour
{
    public int cop;
    
    Manager manager;

    void Awake()
    {
        manager = Manager.Instance;
    }

    void Update()
    {
        GameOver();
    }

    void GameOver()
    {
        if(manager.inGame == false)
        {
            Analytics.CustomEvent("Death", new Dictionary<string, object>
            {
                { "Police", cop },
            });
        }
    }
}
