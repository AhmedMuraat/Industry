using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MuscleMover : MonoBehaviour
{
    public Transform Target;
    public Transform MuscleSphere;
    public LayerMask layerMask;
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
            float h = 2f * Time.deltaTime * -Input.GetAxis("Mouse X");
            Target.transform.Translate(0, h, 0);

            //mousePos.z = 1f;
            //mousePos.x = transform.position.x;
            //// Set the position of the transform to a position defined by the mouse
            //// which is zDistance units away from the screenCamera
            //transform.position = Camera.main.ScreenToWorldPoint(mousePos);

            print("Z: " + mousePos.x);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray rayToCameraPos = new Ray(transform.position, Camera.main.transform.position - transform.position);
            Vector3 dir = gameObject.transform.position - Camera.main.transform.position;
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(Camera.main.transform.position, dir, out hitInfo, 1000, layerMask))
            {
                Debug.Log(hitInfo.collider.name + ", " + hitInfo.collider.tag);
                isHolding = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        { isHolding = false; }

    }
    private void OnMouseDown()
    {
        //if (!isHolding && Input.GetMouseButtonDown(0))
        //{
        //    isHolding = true;
        //    print("mouse pressed");
        //}
        //else
        //{
        //    Debug.Log("no target");
        //}

    }
    private void OnMouseUp()
    {

        //if (isHolding && Input.GetMouseButtonUp(0))
        //{
        //    isHolding = false;
        //    print("mouse NOT pressed");

        //}
    }
}
