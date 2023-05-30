using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MuscleMover : MonoBehaviour
{
    public Transform Target;
    public Transform MuscleSphere;
    public LayerMask layerMask;
    public GameObject[] MoveableJoints;
    public GameObject otherTarget;
    public GameObject Slider;
    Slider sliderElement;
    Vector3 targetPos;

    public bool isHolding;

    public GameObject CurrentJointSelected;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
        sliderElement = Slider.GetComponent<Slider>();
        //MoveableJoints = FindObjectsOfType<GameObject>();
        //MoveableJoints = System.Array.FindAll(MoveableJoints, obj => obj.layer == LayerMask.NameToLayer("Muscle"));
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Ray rayToCameraPos = new Ray(transform.position, Camera.main.transform.position - transform.position);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            Vector3 dir = gameObject.transform.position - Camera.main.transform.position;
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(ray, out hitInfo, 1000, layerMask))
            {
                Debug.Log("Raycast hit an object: " + hitInfo.collider.gameObject.name);
                Debug.Log("Name:" + gameObject.name);

                if (hitInfo.collider.gameObject.name == gameObject.name)
                {
                    isHolding = true;
                    CurrentJointSelected = hitInfo.collider.gameObject;

                }
                else
                {
                    CurrentJointSelected = null;
                }
            }


        }

        else if (Input.touchCount == 0)
        { isHolding = false; }

        if (isHolding)
        {
            float h = 0.2f * Time.deltaTime * -Input.touches[0].deltaPosition.x;
            Target.transform.Translate(0, h, 0);
            Target.transform.position = new Vector3(Target.transform.position.x, Mathf.Clamp(Target.transform.position.y, 0.25f, 1.5f), Target.transform.position.z);

            //if(transform.position.y < 0.25f) Target.transform.position = new Vector3(Target.transform.position.x, 0.25f, Target.transform.position.z);
            //if(transform.position.y > 1.5f) Target.transform.position = new Vector3(Target.transform.position.x, 1.5f, Target.transform.position.z);

            print("Height: " + Target.transform.position.y);


        }

        if (CurrentJointSelected == null)
        {
            Slider.SetActive(false);
        }
        else
        {
            Slider.SetActive(true);
            //sliderElement.value
        }


    }
}
