using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Flashlight : MonoBehaviour
{
    private Light flashLight;
    bool flashEnabled;
    // Start is called before the first frame update
    void Start()
    {
        flashLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && flashEnabled == false)
        {
            flashLight.enabled = true;
            flashEnabled = true;
    
        }
        else if(Input.GetKeyDown(KeyCode.F))
        {
            flashLight.enabled = false;
            flashEnabled = false;
        }
    }
}
