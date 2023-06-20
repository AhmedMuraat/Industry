using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    Touch Touch;
    Quaternion rotY;
    float speed = 0.1f;
    public Quaternion Target = new Quaternion(0, 0.7166f, 0, 0.69740f);
    public Quaternion startPos;
    public float TimeElapsed = 0;
    public float LerpDuration = 10;
    public bool isRotating = false;


    //Start is called before the first frame update
    void Start()
    {
        startPos = transform.rotation;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeElapsed < LerpDuration)
        {
            transform.rotation = Quaternion.Lerp(startPos, Target, TimeElapsed / LerpDuration);
            TimeElapsed += Time.deltaTime;
            isRotating = true;
        }
        else
        {
            isRotating = false;
            if (Input.touchCount == 1)
            {

                Touch = Input.GetTouch(0);
                if (Touch.phase == TouchPhase.Moved)
                {
                    rotY = Quaternion.Euler(0f, Touch.deltaPosition.x * speed, 0f);
                    transform.rotation = rotY * transform.rotation;
                }
            }
        }

        
       

    }
}
