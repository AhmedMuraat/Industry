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

    public bool isHolding;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Input.touchCount);

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Ray rayToCameraPos = new Ray(transform.position, Camera.main.transform.position - transform.position);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            Vector3 dir = gameObject.transform.position - Camera.main.transform.position;
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(ray, out hitInfo, 1000, layerMask))
            {
                if (hitInfo.collider.tag == "Moveable")
                    isHolding = true;
            }
        }
        else if (Input.touchCount == 0)
        { isHolding = false; }

        if (isHolding)
        {

            float h = 0.2f * Time.deltaTime * -Input.touches[0].deltaPosition.x;
            Target.transform.Translate(0, h, 0);
            Target.transform.position = new Vector3(Target.transform.position.x, Mathf.Clamp(Target.transform.position.y, -0.3f, 1.5f), Target.transform.position.z);



        }
    }
}
