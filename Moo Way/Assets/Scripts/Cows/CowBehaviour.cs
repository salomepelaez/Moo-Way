using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowBehaviour : MonoBehaviour
{
    public Transform target;
    
    Vector2 direction;

    void Start()
    {
        target = Points.points[0];
    }
}
