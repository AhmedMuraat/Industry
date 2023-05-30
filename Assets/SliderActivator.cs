using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderActivator : MonoBehaviour
{
    public LayerMask layerMask;
    public GameObject Slider;
    public Material JointMat;
    public GameObject[] otherJoints;
    public GameObject[] otherSliders;
    public Material newMat;
    // Start is called before the first frame update
    void Start()
    {
        JointMat = gameObject.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Touch touch = Input.GetTouch(0);
        Ray rayToCameraPos = new Ray(transform.position, Camera.main.transform.position - transform.position);
        Ray ray = Camera.main.ScreenPointToRay(touch.position);
        Vector3 dir = gameObject.transform.position - Camera.main.transform.position;
        RaycastHit hitInfo = new RaycastHit();
        if (Physics.Raycast(ray, out hitInfo, 1000, layerMask))
        {
            Debug.Log("Raycast hit an object: " + hitInfo.collider.gameObject.name);

            if (hitInfo.collider.gameObject.name == gameObject.name)
            {
                print("muscle pressed");
                Slider.SetActive(true);

                gameObject.GetComponent<Renderer>().material = newMat;

                ResetOtherJoints();
            }
        }
    }

    public void ResetOtherJoints()
    {
        foreach (GameObject joint in otherJoints)
        {
            joint.GetComponent<Renderer>().material = JointMat;
        }

        foreach (GameObject slider in otherSliders)
        {
            slider.SetActive(false);
        }
    }
}
