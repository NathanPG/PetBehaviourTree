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

    public float hunger;
    public float stamina;
    public float sanity;
    public float contentment;
    public float bladder;

    public float dish;

    [Task]
    bool IsTired()
    {
        return sanity<30;
    }
    [Task]
    bool IsHungry()
    {
        return hunger<30;
    }
    [Task]
    bool IsLonely()
    {
        return true;
    }
    [Task]
    bool WantToPlay()
    {
        return true;
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
        contentment = 100;
        bladder = 0;
        dish = 100;
        hour_dis.text = hours.ToString("00") + " :";
        minute_dis.text = minutes.ToString("00");
        log = this.gameObject.GetComponent<Log>();
    }

    void Update() {
        /*
        //TIMER
        minutes += Time.deltaTime;
        minute_dis.text = minutes.ToString("00");
        if (minutes >= 59)
        {
            minutes = 0;
            hours += 1;
            hour_dis.text = hours.ToString("00") + " :";
        }
        if(hours >= 24)
        {
            hours = 0;
            hour_dis.text = hours.ToString("00") + " :";
        }
        //The dog will be hungery after 6 hours
        if(hunger >= 0f)
        {
            hunger -= Time.deltaTime * 0.278f;
        }
        */

    }
   
   
}
