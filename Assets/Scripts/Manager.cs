using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Panda;

public class Manager : MonoBehaviour {

    private float timer;

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
        timer = 0;
    }

    void Update() {
        timer += Time.deltaTime;
        hunger -= Time.deltaTime;
        
    }
   
   
}
