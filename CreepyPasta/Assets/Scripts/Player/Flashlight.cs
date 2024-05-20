// Ryan Armstrong-Byrne
//20/05.2024

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Flashlight : MonoBehaviour
{
    private Light flashLight;
    bool flashEnabled;

    public int maxCharge = 3;
    private int currentCharge = 3;
    private float chargetime = 10;
    private float timer = 1f;

    private void Awake()
    {
        TryGetComponent(out flashLight);
    }
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        ToggleFlashLight(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) == true)
        {
            ToggleFlashLight(!flashLight.enabled);
        }

        if (flashLight.enabled == true)
        {
            timer += Time.deltaTime;
            if (timer >= chargetime)
            {
                currentCharge--;
                if (currentCharge < 0)
                {
                    currentCharge = 0;
                    ToggleFlashLight(false);
                }
                timer = 0;
            }

        }
    }


    public void ToggleFlashLight(bool toggle)
    {
        if(flashLight != null)
        {
            if (toggle == false || toggle == true && (currentCharge > 0 || timer > 0))
        {
                flashLight.enabled = toggle;
            }
        }
    }

}
