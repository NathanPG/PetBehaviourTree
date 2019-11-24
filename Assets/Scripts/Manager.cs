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
    //wants to play
    public float sanity;
    //is lonely 
    public float loneliness;
    /*
    public float contentment;
    public float bladder;
    */
    public bool isSleeping;
    public bool ownerOut;
    public bool dogOut;

    public int Fetch_ThisHour;
    public int Belly_ThisHour;
    public int HowMany15MinsToNewDay;

    public float dish;
    [Task]
    bool DEBUG()
    {
        Debug.Log("HUNGER: " + hunger + ", STAMINA: " + stamina 
            + ", SANITY: " + sanity + ", LONELINESS: " + loneliness);
        return true;
    }
    [Task]
    bool IsTired()
    {
        return stamina < 30;
    }
    [Task]
    bool IsHungry()
    {
        return hunger<30;
    }
    [Task]
    bool IsLonely()
    {
        return loneliness<30;
    }
    [Task]
    bool WantToPlay()
    {
        return sanity<30;
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
            log.AddTextToLog("ERROR, THIS NODE SHOULD NOT BE REACHED");
        }
        return true;
    }


    private void Start() {
        hours = 7;
        minutes = 0;
        hunger = 100;
        sanity = 100;
        stamina = 100;
        loneliness = 100;
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
