using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    public Manager dog;


    // Update is called once per frame
    void Update()
    {
        //loading up the dog dish with food
        if (Input.GetKeyDown(KeyCode.F))
        {
            dog.dish = 100;
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            if (dog.dish>0)
            {
                //dog had a meal
            }
            else
            {
                //you should fill the dish first
            }
        }
        //throw the stick for Fetch the Stick
        else if (Input.GetKeyDown(KeyCode.K))
        {

        }
        //pet the dog???
        else if (Input.GetKeyDown(KeyCode.P))
        {

        }
        //belly rub the dog (helps with boding, but not excess)
        else if (Input.GetKeyDown(KeyCode.B))
        {

        }
        //go for a walk
        else if (Input.GetKeyDown(KeyCode.W))
        {

        }
        //leave the dog alone (do when sleepy)
        else if (Input.GetKeyDown(KeyCode.L))
        {

        }
        else if (Input.GetKeyDown(KeyCode.G))
        {

        }
        else if (Input.GetKeyDown(KeyCode.A))
        {

        }
        //idle-15 mins
        else if (Input.GetKeyDown(KeyCode.I))
        {

        }
        //idle-1 hour
        else if (Input.GetKeyDown(KeyCode.H))
        {

        }
        //start a new day to 7 AM
        else if (Input.GetKeyDown(KeyCode.D))
        {

        }
        //myserious sound (intruder alert)
        else if (Input.GetKeyDown(KeyCode.S))
        {

        }
    }
}
