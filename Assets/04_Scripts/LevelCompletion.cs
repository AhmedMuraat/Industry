using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{

    public GameObject completionScreen;
    public GameObject failedscreen;

    public void Completionscreen()
    {

        completionScreen.SetActive(true);


    }

    public void Failedscreen()
    {
        failedscreen.SetActive(true);
    }
}
