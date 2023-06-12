using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

   
    public void NextScene()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Level Chooser");
    }
}
