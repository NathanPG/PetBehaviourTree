using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour
{
    public Manager dog;

    // Start is called before the first frame update
    void Start()
    {
        dog = GameObject.Find("Boggie").GetComponent<Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        string inputstring = Input.inputString;

        // Look for a number key click
        if (inputstring.Length > 0) {
            Debug.Log(inputstring);

            if (inputstring[0] == 'f') {
                dog.dish = 100;
            }

            
        }
    }
}
