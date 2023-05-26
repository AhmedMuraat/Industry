using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public MuscleMover[] muscleMover;
    Touch Touch;
    Quaternion rotY;
    float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            for (int i = 0; i < muscleMover.Length; i++)
            {
                if (muscleMover[i].isHolding)
                {
                    return;
                }
            }

            Touch = Input.GetTouch(0);
            if (Touch.phase == TouchPhase.Moved)
            {
                rotY = Quaternion.Euler(0f, Touch.deltaPosition.x * speed, 0f);
                transform.rotation = rotY * transform.rotation;
            }
        }
       

    }
}
