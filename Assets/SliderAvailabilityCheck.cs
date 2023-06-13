using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderAvailabilityCheck : MonoBehaviour
{
    public GameObject YBot;
    public GameObject Camera;
    public GameObject Background;
    public Color BackgroundStartColor = new Color32(0, 162, 164, 255);
    public Color FillStartColor = new Color32(0, 231, 214, 255);
    public GameObject Fill;
    public bool AnimationPlaying;
    public bool isRotating;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimationPlaying = YBot.GetComponent<AnimationChooser>().AnimationPlaying;
        isRotating = Camera.GetComponent<CameraRotation>().isRotating;

        if (AnimationPlaying == true)
        {
            ColorBlock colors = gameObject.GetComponent<Slider>().colors;
            colors.normalColor = new Color32(90, 90, 90, 0xFF);
            Background.GetComponent<Image>().color = new Color32(90, 90, 90, 0xFF);
            Fill.GetComponent<Image>().color = new Color32(90, 90, 90, 0xFF);

            gameObject.GetComponent<Slider>().interactable = false;
        }
        else if (isRotating == true)
        {
            ColorBlock colors = gameObject.GetComponent<Slider>().colors;
            colors.normalColor = new Color32(90, 90, 90, 0xFF);
            Background.GetComponent<Image>().color = new Color32(90, 90, 90, 0xFF);
            Fill.GetComponent<Image>().color = new Color32(90, 90, 90, 0xFF);

            gameObject.GetComponent<Slider>().interactable = false;
        }
        else
        {
            ColorBlock colors = gameObject.GetComponent<Slider>().colors;
            colors.normalColor = new Color32(255, 255, 255, 0xFF);
            Background.GetComponent<Image>().color = BackgroundStartColor;
            Fill.GetComponent<Image>().color = FillStartColor;

            gameObject.GetComponent<Slider>().interactable = true;
        }
    }
}
