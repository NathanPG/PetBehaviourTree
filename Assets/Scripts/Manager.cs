using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Panda;

public class Manager : MonoBehaviour {

    public Log log;
    public float minutes;
    public float hours;
    public Text hour_dis;
    public Text minute_dis;

    //ALL DECREASE 100 -> 0
    //is hungry
    public float hunger;
    //is sleepy
    public float stamina;
    //wants to go out
    public float sanity;
    //is not lonely 
    public float accompany;

    //Fetch
    public float Fetch;
    //Belly
    public float Belly;
    /*
    public float contentment;
    public float bladder;
    */
    public bool dogAlone;
    public bool isSleeping;
    public bool ownerOut;
    public bool timepassed;

    public int Fetch_ThisHour;
    public int Belly_ThisHour;
    public int HowMany15MinsToNewDay;

    public float dish;
    [Task]
    bool DEBUG()
    {
        Debug.Log("HUNGER: " + hunger + ", STAMINA: " + stamina 
            + ", SANITY: " + sanity + ", LONELINESS: " + accompany);
        return true;
    }
    [Task]
    bool CheckTimePass() {
        if (timepassed) {
            timepassed = false;
            return true;
        } else {
            return false;
        }
    }

    [Task]
    bool IsDay() {
        return 6 < hours && hours < 18;
    }
    [Task]
    bool IsNight() {
        return hours <= 6 || hours >= 18;
    }
    [Task]
    bool OwnerIsOut() {
        return ownerOut;
    }

    [Task]
    bool IsSleeping() {
        return isSleeping;
    }

    [Task]
    bool IsTired()
    {
        return stamina < 40;
    }
    [Task]
    bool IsHungry()
    {
        return hunger < 40;
    }
    [Task]
    bool IsLonely()
    {
        return accompany < 40;
    }
    [Task]
    bool WantToPlay()
    {
        return sanity < 40;
    }
    [Task]
    bool NeedToGoOut()
    {
        return true;
    }
    [Task]
    bool HearedNoise()
    {
        return true;
    }

    [Task]
    bool Wakeup() {
        isSleeping = false;
        return true;
    }

    [Task]
    bool Snore() {
        if(stamina > 90) {
            log.AddTextToLog("Your dog had a good rest and woke up!");
            isSleeping = false;
            if (sanity > 70) sanity -= 20;
        } else {
            log.AddTextToLog("Your dog is still sleeping soundly.");
        }
        return true;
    }

    [Task]
    bool EatFood() {
        Debug.Log("Dish: " + dish + ", hunger: " + hunger);
        float amount = 100 - hunger;
        if(dish >= amount) {
            dish -= amount;
            hunger += amount;
            log.AddTextToLog("Boggie ate some food in the dish");
        } else if(dish < amount && dish > 0) {
            hunger += dish;
            dish = 0;
            log.AddTextToLog("Boggie ate all food in the dish");
        } else{
            if (!ownerOut) {
                log.AddTextToLog("Boggie looked at the empty dish and softly barked at you, looks like he's hungry...");
            } else {
                log.AddTextToLog("Normally at this time Boggie would be hungry... WAIT, did you fill the dish before coming out?");
            }
        }
        return true;
    }

    [Task]
    bool Sleep() {
        isSleeping = true;
        if (!ownerOut) {
            log.AddTextToLog("Boggie felt too tired an went to sleep.");
        }
        return true;
    }

    [Task]
    bool LookForPet() {
        log.AddTextToLog("Boggie is running around your feet, he must be missing you so much!");
        log.AddTextToLog("Maybe");
        return true;
    }

    [Task]
    bool LookOutside() {
        log.AddTextToLog("Boggie sits at the window and stear at the horizon, he must be willing to have a run out side.");
        return true;
    }

    private void Start() {
        hours = 7;
        minutes = 0;
        hunger = 100;
        sanity = 100;
        stamina = 100;
        accompany = 100;
        Fetch = 0;
        Belly = 0;
        dogAlone = false;
        //contentment = 100;
        //bladder = 0;
        HowMany15MinsToNewDay = 96;
        dish = 100;
        hour_dis.text = hours.ToString("00") + " :";
        minute_dis.text = minutes.ToString("00");
        log = this.gameObject.GetComponent<Log>();
    }

    void Update() {
    }

}
