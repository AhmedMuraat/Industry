using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMusleMover : MonoBehaviour
{
    public List<GameObject> Target = new List<GameObject>();

    [HideInInspector]
    public Slider Slider;
    // Start is called before the first frame update
    void Start()
    {
        Slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Target.Count; i++)
        {

            Vector3 newPosition = Target[i].transform.position;
            newPosition.y = Slider.value;

            Target[i].transform.position = newPosition;
        }
    }
}
