// Ryan Armstrong-Byrne
//20/05.2024

using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    private Light flashLight;
    bool flashEnabled;

    public int maxCharge = 3;
    public int currentCharge = 3;
    public float chargetime = 10;
    public float timer = 1f;
    public Image Image;
    public float holdInteract = 0f;
    public float interactTime = 5;
    private Coroutine CoRo;
    public Image GetChargeBar;
    public bool Actionstarted;
    public GameObject Charge_Icon_1;
    public GameObject Charge_Icon_2;
    public GameObject Charge_Icon_3;
    public GameObject Hold_E;
    public GameObject Battery;
    public GameObject Battery2;
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

        if (currentCharge > maxCharge)
        {
            currentCharge = maxCharge;
        }
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
            Image.fillAmount = timer / 10;
            if (currentCharge == 0 && flashLight.enabled == false)
            {
                Image.fillAmount = 1;
            }

        }
       
        if (currentCharge >= 3)
        {
            Charge_Icon_3.SetActive(true);
            Charge_Icon_2.SetActive(true);
            Charge_Icon_1.SetActive(true);
        }
        else if (currentCharge == 2)
        {
            Charge_Icon_3.SetActive(false);
            Charge_Icon_2.SetActive(true);
            Charge_Icon_1.SetActive(true);
        }
        else if (currentCharge == 1)
        {
            Charge_Icon_3.SetActive(false);
            Charge_Icon_2.SetActive(false);
            Charge_Icon_1.SetActive(true);
        }
        else if (currentCharge == 0)
        {
            Charge_Icon_3.SetActive(false);
            Charge_Icon_2.SetActive(false);
            Charge_Icon_1.SetActive(false);
        }
    }


    public void GetCharge()
    {

        CoRo = StartCoroutine(ChargeRoutine());
        Actionstarted = true;
        if (holdInteract >= interactTime)
        {
            holdInteract = interactTime;

        }
    }
            
    public void GetBattery()
    {
        Debug.Log("charge+");
        currentCharge += 1;
        Battery.gameObject.SetActive(false);
        
      
        
    }
    public void GetBattery2()
    {
        Debug.Log("charge+");
        currentCharge += 1;
        Battery2.gameObject.SetActive(false);



    }



    private IEnumerator ChargeRoutine()
    {
        while (!Input.GetKeyUp(KeyCode.E))
        {
            GetChargeBar.fillAmount = holdInteract / 5;
            holdInteract += Time.deltaTime;
            if (holdInteract >= interactTime)
            {
                Debug.Log("Charge Added");
                currentCharge += 1;

                holdInteract = 0;
                GetChargeBar.fillAmount = 0;
                Hold_E.SetActive(false);
                break;
            }
            yield return null;
        }

        // This should handle when E is released before full charge
        holdInteract = 0;
        GetChargeBar.fillAmount = 0;
        Hold_E.SetActive(false);
    }
    public void ToggleFlashLight(bool toggle)
    {
        if (flashLight != null)
        {
            if (toggle == false || toggle == true && (currentCharge > 0 || timer > 0))
            {
                flashLight.enabled = toggle;
            }
        }
    }
}
