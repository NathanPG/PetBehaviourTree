using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Panda;

public class InputListener : MonoBehaviour
{
    public Manager dog;
    public Log log;
    public float timer;

    // Start is called before the first frame update 
    void Start() {
        dog = GameObject.Find("GameController").GetComponent<Manager>();
        log = GameObject.Find("GameController").GetComponent<Log>();
        timer = 0f;
    }

    // Update is called once per frame 
    void Update() {
        timer += Time.deltaTime;
        if(timer >= 15) {
            timer = 0f;
            Add15Mins();
        }

        string inputstring = Input.inputString;

        // Look for a number key click 
        if (inputstring.Length > 0) {
            Debug.Log(inputstring);

            if (inputstring[0] == 'f' || inputstring[0] == 'F') {
                LoadDish();
            }
            if (inputstring[0] == 't' || inputstring[0] == 'T') {
                Treat();
            }
            if (inputstring[0] == 'k' || inputstring[0] == 'K') {
                Fetch();
            }
            if (inputstring[0] == 'p' || inputstring[0] == 'P') {
                Pet();
            }
            if (inputstring[0] == 'b' || inputstring[0] == 'B') {
                BellyRub();
            }
            if (inputstring[0] == 'w' || inputstring[0] == 'W') {
                Walk();
            }
            if (inputstring[0] == 'l' || inputstring[0] == 'L') {
                LeaveAlone();
            }
            if (inputstring[0] == 'g' || inputstring[0] == 'G') {
                Work();
            }
            if (inputstring[0] == 'a' || inputstring[0] == 'A') {
                Return();
            }
            if (inputstring[0] == 'i' || inputstring[0] == 'I') {
                Add15Mins();
            }
            if (inputstring[0] == 'h' || inputstring[0] == 'H') {
                Add1Hour();
            }
            if (inputstring[0] == 'd' || inputstring[0] == 'D') {
                StartNewDay();
            }
            if (inputstring[0] == 's' || inputstring[0] == 'S') {
                Noise();
            }
        }
    }

    //I
    public void Add15Mins()
    {
        dog.timepassed = true;
        log.AddTextToLog("15 mins passed");
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
            if (dog.stamina <= 95) dog.stamina += 5;
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
        dog.sanity -= 4;
        if (dog.sanity < 0) dog.sanity = 0;
        //LONELINESS
        if (dog.ownerOut)
        {
            dog.accompany -= 5;
            if (dog.accompany < 0) dog.accompany = 0;
        }
        else
        {
            dog.accompany -= 3;
            if (dog.accompany < 0) dog.accompany = 0;
        }

    }

    //H, Value changes four times faster than I
    public void Add1Hour()
    {
        dog.timepassed = true;
        log.AddTextToLog("1 hour passed!");
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
            dog.sanity -= 16;
            if (dog.sanity < 0) dog.sanity = 0;
            //LONELINESS
            if (dog.ownerOut)
            {
                dog.accompany -= 20;
                if (dog.accompany < 0) dog.accompany = 0;
            }
            else
            {
                dog.accompany -= 12;
                if (dog.accompany < 0) dog.accompany = 0;
            }
    }

    //D
    public void StartNewDay()
    {
        dog.timepassed = true;
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
            dog.sanity -= 4 * dog.HowMany15MinsToNewDay;
            if (dog.sanity < 0) dog.sanity = 0;
            //LONELINESS
            if (dog.ownerOut)
            {
                dog.accompany -= 5 * dog.HowMany15MinsToNewDay;
                if (dog.accompany < 0) dog.accompany = 0;
            }
            else
            {
                dog.accompany -= 3 * dog.HowMany15MinsToNewDay;
                if (dog.accompany < 0) dog.accompany = 0;
            }

    }

    //F
    public void LoadDish()
    {
        if (dog.dish == 100)
        {
            log.AddTextToLog("Dish already full!");
        }
        else
        {
            dog.dish = 100;
        }
    }

    //T
    public void Treat()
    {
        if (dog.isSleeping)
        {
            log.AddTextToLog("Boggie is sleeping! You may not want to bother him.");
            return;
        }
        if (dog.ownerOut)
        {
            log.AddTextToLog("You miss your dog a lot! But you at work now.");
            return;
        }
        if (dog.hunger >= 75) {
            log.AddTextToLog("Boggie seems pretty full at this time...");
        }
        else if(dog.hunger >= 30) {
            log.AddTextToLog("Boggie looks happy with the treat!");
            dog.hunger += 10;
            dog.accompany = dog.accompany <= 50 ? dog.accompany + 10 : dog.accompany;
        } else {
            log.AddTextToLog("Boggie rushed towards you and devoured the treat...");
            dog.hunger += 10;
            log.AddTextToLog("Boggie is stearing at your hand, maybe he wants more?");
        }
    }

    //K
    public void Fetch()
    {
        if (dog.isSleeping)
        {
            log.AddTextToLog("Boggie is sleeping! You may not want to bother him.");
            return;
        }
        if (dog.ownerOut)
        {
            log.AddTextToLog("You miss your dog a lot! But you at work now.");
            return;
        }
        if (dog.Fetch <= 10)
        {
            dog.Fetch += 5;
            dog.accompany += 15;
            log.AddTextToLog("Boggie absolutely wants to play more!");
        }
        else if (dog.Fetch > 10 && dog.Fetch <= 50)
        {
            dog.Fetch += 10;
            dog.accompany += 10;
            log.AddTextToLog("Boggie feels happy playing!");
        }
        else if (dog.Fetch > 50)
        {
            dog.Fetch += 15;
            if (dog.Fetch > 100)
            {
                dog.Fetch = 100;
                dog.accompany -= 10;
                log.AddTextToLog("Boggie does not want to fetch now.");
            }
            else
            {
                dog.accompany += 5;
                log.AddTextToLog("Boggie is getting tired.");
            }
        }
    }

    //P
    public void Pet()
    {
        if (dog.isSleeping)
        {
            log.AddTextToLog("Boggie is sleeping! You may not want to bother him.");
            return;
        }
        if (dog.ownerOut)
        {
            log.AddTextToLog("You miss your dog a lot! But you at work now.");
            return;
        }
        dog.accompany += 5;
        log.AddTextToLog("You are petting Boggie~");
    }

    //B
    public void BellyRub()
    {
        if (dog.isSleeping)
        {
            log.AddTextToLog("Boggie is sleeping! You may not want to bother him.");
            return;
        }
        if (dog.ownerOut)
        {
            log.AddTextToLog("You miss your dog a lot! But you are at work now.");
            return;
        }
        dog.dogAlone = false;
        if (dog.Belly <= 10)
        {
            dog.Belly += 5;
            dog.accompany += 15;
            log.AddTextToLog("Boggie wants more, rub him.");
        }
        else if (dog.Belly > 10 && dog.Belly <= 50)
        {
            dog.Belly += 10;
            dog.accompany += 10;
            log.AddTextToLog("Boggie feels comfortable!");
        }
        else if (dog.Belly > 50)
        {
            dog.Belly += 15;
            if (dog.Belly > 100)
            {
                dog.Belly = 100;
                dog.accompany -= 10;
                log.AddTextToLog("Boggie feels good enough.");
            }
            else
            {
                dog.accompany += 5;
                log.AddTextToLog("Boggie does not look so happy, you may want to stop.");
            }
        }
    }

    //W
    public void Walk()
    {
        if (dog.isSleeping)
        {
            log.AddTextToLog("Boggie is sleeping! You may not want to bother him.");
            return;
        }
        if (dog.ownerOut)
        {
            log.AddTextToLog("You miss your dog a lot! But you are at work now.");
            return;
        }
        dog.dogAlone = false;
        log.AddTextToLog("Come on, Boggie! Lets go for a walk");
        Add1Hour();
    }

    //L
    public void LeaveAlone()
    {
        log.AddTextToLog("You leave Boggie alone.");
        dog.dogAlone = true;
    }

    //G
    public void Work()
    {
        if (dog.ownerOut)
        {
            log.AddTextToLog("You forget you are working? Concentrate!");
            return;
        }
        dog.ownerOut = true;
        log.AddTextToLog("You are going to work now!");
        dog.dogAlone = true;
        return;
    }

    //A
    public void Return()
    {
        if (!dog.ownerOut)
        {
            log.AddTextToLog("You are at home. Dont you remember anything?");
            return;
        }
        log.AddTextToLog("You get back to home after work!");
        return;
    }

    //S
    public void Noise()
    {

    }

}
