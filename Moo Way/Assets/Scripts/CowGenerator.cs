using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowGenerator : MonoBehaviour
{
    public GameObject c;
    
    void Start()
    {
        GenerateCow();
    }

    public void GenerateCow()
    {
        GameObject cow = Instantiate(c, Vector3.zero, Quaternion.identity);
        Vector3 pos = new Vector3();
        pos.x = Random.Range(41f, 120f);
        pos.y= 0.1f;
    }
}
