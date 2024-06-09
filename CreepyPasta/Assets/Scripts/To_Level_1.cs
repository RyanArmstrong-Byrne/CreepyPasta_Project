using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class To_Level_1 : MonoBehaviour
{
    public void PlayCard()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
