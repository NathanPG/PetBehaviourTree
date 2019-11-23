using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class InputListener : MonoBehaviour
{
    public Manager dog;
    public Log log;

    [Task]
    //I
    public bool Add15Mins()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (dog.minutes == 45)
            {
                if (dog.hours == 23)
                {
                    dog.hours = 0;
                }
                else
                {
                    dog.hours += 1;
                }
                dog.minutes = 0;
            }
            else
            {
                dog.minutes += 15;
            }
            dog.hour_dis.text = dog.hours.ToString("00") + " :";
            dog.minute_dis.text = dog.minutes.ToString("00");
            return true;
        }
        return false;
    }

    [Task]
    //H
    public bool Add1Hour()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (dog.minutes == 45)
            {
                if (dog.hours == 23)
                {
                    dog.hours = 0;
                }
                else
                {
                    dog.hours += 1;
                }
            }
            dog.hour_dis.text = dog.hours.ToString("00") + " :";
            return true;
        }
        return false;
    }

    [Task]
    //D
    public bool StartNewDay()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            dog.minutes = 0;
            dog.hours = 7;
            dog.hour_dis.text = dog.hours.ToString("00") + " :";
            dog.minute_dis.text = dog.minutes.ToString("00");



            return true;
        }
        return false;
    }
    [Task]
    //F
    public bool LoadDish()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            dog.dish = 100;
            return true;
        }
        return false;
    }
    [Task]
    //T
    public bool TreatDog()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if(dog.dish > 0)
            {
                log.AddTextToLog("Have a great meal, Boggie!");
                return true;
            }
            else
            {
                log.AddTextToLog("Oh, you forget to load the dish!");
                return false;
            }
        }
        return false;
    }
    /*
     * THIS BLOCK INDICATES WHICH HAS NOT BEEN DONE
    public void GetInput()
    {
        bool validInput = false;
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
            if (dog.minutes == 45)
            {
                if(dog.hours == 23)
                {
                    dog.hours = 0;
                }
                else
                {
                    dog.hours += 1;
                } 
            }
            else
            {
                dog.minutes += 15;
            }
            dog.hour_dis.text = dog.hours.ToString("00") + " :";
            dog.minute_dis.text = dog.minutes.ToString("00");
            log.AddTextToLog("15 mins later...");
            validInput = true;
        }
        //idle-1 hour
        else if (Input.GetKeyDown(KeyCode.H))
        {
            if (dog.minutes == 45)
            {
                if (dog.hours == 23)
                {
                    dog.hours = 0;
                }
                else
                {
                    dog.hours += 1;
                }
            }
            log.AddTextToLog("1 hour later...");
            dog.hour_dis.text = dog.hours.ToString("00") + " :";
            validInput = true;
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
    */

}
