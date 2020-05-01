using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTr;    

    void Update()
    {
        Move();
    }

    public void Move()
    {
        transform.position = new Vector3(playerTr.transform.position.x, playerTr.transform.position.y, transform.position.z);
    }
}
