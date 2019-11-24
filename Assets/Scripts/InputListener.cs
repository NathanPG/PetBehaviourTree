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
                    dog.HowMany15MinsToNewDay = 96;
                }
                else
                {
                    dog.hours += 1;
                    dog.HowMany15MinsToNewDay -= 1;
                }
                dog.minutes = 0;
            }
            else
            {
                dog.minutes += 15;
                dog.HowMany15MinsToNewDay -= 1;

            }
            dog.hour_dis.text = dog.hours.ToString("00") + " :";
            dog.minute_dis.text = dog.minutes.ToString("00");

            //STAMINA
            if (dog.isSleeping)
            {
                if(dog.stamina<=95) dog.stamina += 5;
            }
            else
            {
                dog.stamina -= 4;
                if (dog.stamina < 0) dog.stamina = 0;
            }
            //HUNGER
            dog.hunger -= 3;
            if (dog.hunger < 0) dog.hunger = 0;
            //SANITY
            if (!dog.dogOut)
            {
                dog.sanity -= 4;
                if (dog.sanity < 0) dog.sanity = 0;
            }
            //LONELINESS
            if (dog.ownerOut)
            {
                dog.loneliness -= 5;
                if (dog.loneliness < 0) dog.loneliness = 0;
            }
            else
            {
                dog.loneliness -= 3;
                if (dog.loneliness < 0) dog.loneliness = 0;
            }
            return true;
        }
        return false;
    }

    [Task]
    //H, Value changes four times faster than I
    public bool Add1Hour()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (dog.hours == 23)
            {
                dog.hours = 0;
                dog.HowMany15MinsToNewDay = 96;
            }
            else
            {
                dog.hours += 1;
                dog.HowMany15MinsToNewDay -= 4;
            }
            dog.hour_dis.text = dog.hours.ToString("00") + " :";
            //STAMINA
            if (dog.isSleeping)
            {
                if (dog.stamina <= 95) dog.stamina += 20;
            }
            else
            {
                dog.stamina -= 16;
                if (dog.stamina < 0) dog.stamina = 0;
            }
            //HUNGER
            dog.hunger -= 12;
            if (dog.hunger < 0) dog.hunger = 0;
            //SANITY
            if (!dog.dogOut)
            {
                dog.sanity -= 16;
                if (dog.sanity < 0) dog.sanity = 0;
            }
            //LONELINESS
            if (dog.ownerOut)
            {
                dog.loneliness -= 20;
                if (dog.loneliness < 0) dog.loneliness = 0;
            }
            else
            {
                dog.loneliness -= 12;
                if (dog.loneliness < 0) dog.loneliness = 0;
            }
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
            //STAMINA
            if (dog.isSleeping)
            {
                if (dog.stamina <= 95) dog.stamina += 5 * dog.HowMany15MinsToNewDay;
            }
            else
            {
                dog.stamina -= 4 * dog.HowMany15MinsToNewDay;
                if (dog.stamina < 0) dog.stamina = 0;
            }
            //HUNGER
            dog.hunger -= 3 * dog.HowMany15MinsToNewDay;
            if (dog.hunger < 0) dog.hunger = 0;
            //SANITY
            if (!dog.dogOut)
            {
                dog.sanity -= 4 * dog.HowMany15MinsToNewDay;
                if (dog.sanity < 0) dog.sanity = 0;
            }
            //LONELINESS
            if (dog.ownerOut)
            {
                dog.loneliness -= 5 * dog.HowMany15MinsToNewDay;
                if (dog.loneliness < 0) dog.loneliness = 0;
            }
            else
            {
                dog.loneliness -= 3 * dog.HowMany15MinsToNewDay;
                if (dog.loneliness < 0) dog.loneliness = 0;
            }


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
            if(dog.dish == 100)
            {
                log.AddTextToLog("Dish already full!");
                return false;
            }
            else
            {
                dog.dish = 100;
                return true;
            }  
        }
        return false;
    }

    [Task]
    //T
    public bool TreatDogInput()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if(dog.dish > 0)
            {
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

    [Task]
    //K
    public bool FetchInput()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            return true;
        }
        return false;
    }

    [Task]
    //P
    public bool PetDogInput()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            return true;
        }
        return false;
    }

    [Task]
    //B
    public bool BellyRubInput()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            return true;
        }
        return false;
    }

    [Task]
    //W
    public bool WalkInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            return true;
        }
        return false;
    }

    [Task]
    //L
    public bool LeaveAloneInput()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            return true;
        }
        return false;
    }

    [Task]
    //G
    public bool WorkInput()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            return true;
        }
        return false;
    }

    [Task]
    //A
    public bool ReturnInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            return true;
        }
        return false;
    }

    [Task]
    //S
    public bool NoiseInput()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            return true;
        }
        return false;
    }

}
