using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomizer : MonoBehaviour

{
    [Tooltip("Assign The objects you want to randomly spawn")]
    [SerializeField] GameObject[] objects = null;
    [SerializeField] bool debug = false;

    private void Awake()
    {
        // Gets a number from 0 to the amount of objects in the array and sets it to 'num'
        int num = Random.Range(0, objects.Length);

        // Loops for each object in the array 'objects'
        for (int i = 0; i < objects.Length; i++)
        {
            // If the current loop of 'i' does not equal 'num' set the objects active state to false
            if (i != num)
            {
                objects[i].SetActive(false);
            }
        }
        // If debug is true. Logs to console the objects name that was spawned
        if (debug == true)
        {
            Debug.Log("Object: " + objects[num].name + "has spawned.");
        }
    }
}