using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IntroductionGame : MonoBehaviour
{

    // The object with the script you want to disable

    public GameObject introductionUI;
    public GameObject step1UI;
    public GameObject step2UI;
    public LayerMask layerMask;

    bool StepOneDone;
    bool StepTwoDone;
    bool StepThreeDone;


    // Start is called before the first frame update
    void Start()
    {
        introductionUI.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && !StepOneDone)
        {
            introductionUI.SetActive(false);

            step1UI.SetActive(true);
            StepOneDone = true;
        }
        else if (!StepTwoDone && StepOneDone)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(ray, out hitInfo, 1000, layerMask))
            {
                Debug.Log("Raycast hit an object: " + hitInfo.collider.gameObject.name);

                if (hitInfo.collider.tag == "Moveable")
                {
                    StepTwoDone = true;
                    step1UI.SetActive(false);
                    step2UI.SetActive(true);
                }
            }
        }




    }
   
    public void CheckStep3()
    {

        if (!StepThreeDone && StepTwoDone)
        {
            step2UI.SetActive(false);
        }
    }
}
