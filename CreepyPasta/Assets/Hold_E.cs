using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold_E : MonoBehaviour
{
    public GameObject E; // Reference to the UI element
    public GameObject Crosshair;

    // This method is called when another collider enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            E.gameObject.SetActive(true);
            Crosshair.gameObject.SetActive(false);
        }
    }

    // This method is called when another collider exits the trigger collider
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            E.gameObject.SetActive(false);
            Crosshair.gameObject.SetActive(true);
        }
    }
}
