using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JointMover : MonoBehaviour
{
    public LayerMask layerMask;
    public List<GameObject> MoveableJoints = new List<GameObject>();
    public GameObject slider;

    // Start is called before the first frame update
    void Start()
    {
        MoveableJoints.AddRange(GameObject.FindGameObjectsWithTag("Moveable"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Ray rayToCameraPos = new Ray(transform.position, Camera.main.transform.position - transform.position);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            Vector3 dir = gameObject.transform.position - Camera.main.transform.position;
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(ray, out hitInfo, 1000, layerMask))
            {

                if (hitInfo.collider.gameObject.tag == "Moveable")
                {
                    print("muscle pressed");
                    slider.SetActive(true);

                    //gameObject.GetComponent<Renderer>().material = newMat;

                    //ResetOtherJoints();
                }
            }
        }
    }
}
