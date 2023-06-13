using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvailabilityCheck : MonoBehaviour
{
    public GameObject YBot;
    public GameObject Camera;
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
            gameObject.GetComponent<Image>().color = new Color32(90, 90, 90, 0xFF);
            gameObject.GetComponent<Button>().interactable = false;
        }
        else if (isRotating == true)
        {
            gameObject.GetComponent<Image>().color = new Color32(90, 90, 90, 0xFF);
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 0xFF);
            gameObject.GetComponent<Button>().interactable = true;
        }
    }
}
