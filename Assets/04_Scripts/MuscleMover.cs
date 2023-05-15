using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MuscleMover : MonoBehaviour
{
    public Transform Target;
    public Transform MuscleSphere;

    Vector3 targetPos;

    bool isHolding;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHolding)
        {

            Vector3 mousePos = Input.mousePosition;
            float h = 2f * Time.deltaTime *-Input.GetAxis("Mouse X");
            Target.transform.Translate(0, h, 0);

            //mousePos.z = 1f;
            //mousePos.x = transform.position.x;
            //// Set the position of the transform to a position defined by the mouse
            //// which is zDistance units away from the screenCamera
            //transform.position = Camera.main.ScreenToWorldPoint(mousePos);

            print("Z: " + mousePos.x);
        }


    }
    private void OnMouseDown()
    {
        if (!isHolding && Input.GetMouseButtonDown(0))
        {
            isHolding = true;
            print("mouse pressed");
        }

    }
    private void OnMouseUp()
    {

        if (isHolding && Input.GetMouseButtonUp(0))
        {
            isHolding = false;
            print("mouse NOT pressed");

        }
    }
}
