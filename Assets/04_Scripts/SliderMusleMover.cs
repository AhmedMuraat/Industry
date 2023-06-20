using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderMusleMover : MonoBehaviour
{
    public GameObject Target;

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
        
    }
}
