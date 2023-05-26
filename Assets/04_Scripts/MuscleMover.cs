using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MuscleMover : MonoBehaviour
{
    public Transform Target;
    public Transform MuscleSphere;
    public LayerMask layerMask;
    public GameObject[] MoveableJoints;
    public GameObject otherTarget;
    Vector3 targetPos;

    bool isHolding;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
        MoveableJoints = FindObjectsOfType<GameObject>();
        //MoveableJoints = System.Array.FindAll(MoveableJoints, obj => obj.layer == LayerMask.NameToLayer("Muscle"));
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Target.transform.position);
        if (isHolding)
        {

            Vector3 mousePos = Input.mousePosition;
            float h = 2f * Time.deltaTime * -Input.GetAxis("Mouse X");
            Target.transform.Translate(0, h, 0);
            Target.transform.position = new Vector3(Target.transform.position.x, Mathf.Clamp(Target.transform.position.y, -0.3f, 1.5f), Target.transform.position.z);

            print(gameObject.name);


            //mousePos.z = 1f;
            //mousePos.x = transform.position.x;
            //// Set the position of the transform to a position defined by the mouse
            //// which is zDistance units away from the screenCamera
            //transform.position = Camera.main.ScreenToWorldPoint(mousePos);

            //print("Z: " + mousePos.x);
        }

        if (Input.GetMouseButtonDown(0))
        {
            //Ray rayToCameraPos = new Ray(transform.position, Camera.main.transform.position - transform.position);
            //Vector3 dir = gameObject.transform.position - Camera.main.transform.position;
            //RaycastHit hitInfo = new RaycastHit();
            //if (Physics.Raycast(Camera.main.transform.position, dir, out hitInfo, 1000, layerMask))
            //{
            //    if (hitInfo.collider.tag == "Moveable")
            //    { isHolding = true;
            //        print(hitInfo.collider.name);
            //    }


            //}

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Raycast hit an object: " + hit.collider.gameObject.name);

                if (hit.collider.gameObject.name == gameObject.name)
                {
                    isHolding = true;


                    //foreach (GameObject joint in MoveableJoints)
                    //{
                    //    if (joint != gameObject)
                    //    {
                    //        joint.GetComponent<MuscleMover>().enabled = false;
                    //    }
                    //}
                }
            }


        }
        else if (Input.GetMouseButtonUp(0))
        { 
            isHolding = false;

            //foreach (GameObject joint in MoveableJoints)
            //{
            //        joint.GetComponent<MuscleMover>().enabled = true;
            //}
        }

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
