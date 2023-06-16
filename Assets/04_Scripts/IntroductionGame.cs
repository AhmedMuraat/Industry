using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionGame : MonoBehaviour
{

    // The object with the script you want to disable

    public GameObject introductionUI;
    public GameObject step1UI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            introductionUI.SetActive(false);

            step1UI.SetActive(true);
        }

        

    }
}
