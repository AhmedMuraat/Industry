using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompletion : MonoBehaviour
{

    public GameObject completionScreen;
    public GameObject failedscreen;

    public void Completionscreen()
    {
        int id = int.Parse(SceneManager.GetActiveScene().name.Split(" ")[1]);

        PlayerPrefs.SetInt("UnlockedLevel", id);
        PlayerPrefs.Save();

        completionScreen.SetActive(true);
    }

    public void Failedscreen()
    {
        failedscreen.SetActive(true);
    }
}
