using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    private float speed = 3.5f;
    
    public Joystick joystick;

    private Vector2 direction;

    public static bool canWalk;
    public static bool getOut;
    private bool empty;
    
    private int fuel;

    public TextMeshProUGUI fuelText;
     
    void Start()
    {
        InvokeRepeating("LoseFuel", 5f, 1f);
        fuel = 10;

        canWalk = false;
        getOut = false;
        empty = false;
    }

    void Update()
    {
        if(AlienMovement.alienControl == false && Manager.inGame == true)
        {
            direction = joystick.Direction * speed * Time.deltaTime;
            transform.position += new Vector3(direction.x, direction.y, 0f);
        }

        LimitateAxis();
    }

    private void LimitateAxis()
    {
        if (gameObject.transform.position.y >= 7.5f)
        {
            transform.position = new Vector3(transform.position.x, 7.5f, 0);
        }

        else if (gameObject.transform.position.y <= 2.1f)
        {
            transform.position = new Vector3(transform.position.x, 2.1f, 0);
        }

        else if (gameObject.transform.position.x <= -20f)
        {
            transform.position = new Vector3(-20f, transform.position.y, 0);
        }

        else if (gameObject.transform.position.x <= -163f)
        {
            transform.position = new Vector3(-163f, transform.position.y, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground")
        {
            canWalk = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Ground")
        {
            canWalk = false;
        }
    }

    void LoseFuel()
    {
        if(empty == false && AlienMovement.alienControl == false)
        {
            fuel = fuel - 1;   
            if(fuel <= 0)
            {
                empty = true; 
                getOut = true;  
                StartCoroutine("FuelText");    
                InvokeRepeating("GetFuel", 5f, 1f);    
            }    
        }
    }

    void GetFuel()
    {
        if(empty == true)
        {
            fuel = fuel + 1;

            if(fuel >= 10)
            {
                empty = false;
            }
        }
    }

    IEnumerator FuelText()
    {
        fuelText.text = "You ran out of energy, let the ship load";

        yield return new WaitForSeconds(4);

        fuelText.text = "";
    }
}
