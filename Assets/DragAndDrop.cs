using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Vector3 mousePosition;
    public CharacterJoint joint;
    public Rigidbody rb;
    private Vector3 initialLocalPosition;
    private Quaternion initialLocalRotation;

    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    void Start()
    {
        joint = gameObject.GetComponent<CharacterJoint>();
        rb = gameObject.GetComponent<Rigidbody>();
        initialLocalPosition = transform.localPosition;
        initialLocalRotation = transform.localRotation;
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
        //gameObject.GetComponent<Rigidbody>().isKinematic = false;

        rb.isKinematic = false;
        Vector3 mouseDelta = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(mouseDelta.y, mouseDelta.x) * Mathf.Rad2Deg;
        Quaternion newRotation = Quaternion.Euler(0, 0, angle);
        joint.anchor = newRotation * initialLocalPosition;
        joint.connectedAnchor = joint.connectedBody.transform.InverseTransformPoint(transform.position);

    }

    private void OnMouseUp()
    {
        //gameObject.GetComponent<Rigidbody>().isKinematic = true;

        rb.isKinematic = true;
        transform.localPosition = initialLocalPosition;
        transform.localRotation = initialLocalRotation;
    }
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        if (!rb.isKinematic)
        {
            Vector3 newWorldAnchor = rb.transform.TransformPoint(joint.anchor);
            Vector3 newConnectedAnchor = joint.connectedBody.transform.InverseTransformPoint(newWorldAnchor);
            joint.connectedAnchor = newConnectedAnchor;
        }
    }
}
