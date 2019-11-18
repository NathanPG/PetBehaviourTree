using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Panda;

public class Manager : MonoBehaviour {

    private float minutes;
    private float hours;

    public float hunger;
    public float stamina;
    public float sanity;
    public float contentment;
    public float bladder;

    public float dish;


    [Task]
    bool EatFood() {
        Debug.Log("Dish: " + dish + ", hunger: " + hunger);
        float amount = 100 - hunger;
        if(dish >= amount) {
            dish -= amount;
            hunger += amount;
            Debug.Log("ate some");
            return true;
        } else if(dish < amount && dish > 0) {
            hunger += dish;
            dish = 0;
            Debug.Log("ate all");
            return true;
        } else{
            Debug.Log("no food");
            return false;
        }
    }

    [Task]
    bool IsHungry() {
        Debug.Log("Hunger: " + hunger);
        return hunger > 60;
    }

    private void Start() {
        hours = 7;
        minutes = 60;
        hunger = 100;
        sanity = 100;
        contentment = 100;
        bladder = 0;
        dish = 100;

    }

    void Update() {
        //TIMER
        minutes += Time.deltaTime;
        if(minutes >= 60)
        {
            minutes = 0;
            hours += 1;
        }
        if(hours >= 24)
        {
            hours = 0;
        }

        //The dog will be hungery after 6 hours
        if(hunger >= 0f)
        {
            hunger -= Time.deltaTime * 0.278f;
        }

    }
   
   
}
