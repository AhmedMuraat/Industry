using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuscleSlider : MonoBehaviour
{

    public GameObject slider;
    public float sliderValue;
    public List<Transform> Target = new List<Transform>();
    public GameObject Camera;
    public float directionMultiplier;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sliderValue = slider.gameObject.GetComponent<Slider>().value;
        print(sliderValue);
        for (int i = 0; i < Target.Count; i++)
        {

            Vector3 newPosition = Target[i].position;
            newPosition.y = sliderValue * directionMultiplier;

            Target[i].position = newPosition;
        }
    }

    public void OnSliderPress()
    {
        Debug.Log("slider pressed");

        Camera.GetComponent<CameraRotation>().enabled = false;
    }

    public void OnSliderUp()
    {
        Camera.GetComponent<CameraRotation>().enabled = true;
    }
}
