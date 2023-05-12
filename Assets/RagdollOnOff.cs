using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollOnOff : MonoBehaviour
{
    public BoxCollider mainCollider;
    public Rigidbody MainRigidbody;
    public GameObject FullRig;
    public Animator StandUpAnimation;
    public float FallDelayTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        mainCollider = gameObject.GetComponent<BoxCollider>();
        MainRigidbody = gameObject.GetComponent<Rigidbody>();
        StandUpAnimation = gameObject.GetComponent<Animator>();
        GetRagdollElements();
        RagdollModeOff();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(FallOver());
    }

    Collider[] RagdollColliders;
    Rigidbody[] LimbsRigidBodies;
    void GetRagdollElements()
    {
        RagdollColliders = FullRig.GetComponentsInChildren<Collider>();
        LimbsRigidBodies = FullRig.GetComponentsInChildren<Rigidbody>();
    }

    void RagdollmodeOn()
    {
        foreach (Collider col in RagdollColliders)
        {
            col.enabled = true;
        }

        foreach (Rigidbody rigid in LimbsRigidBodies)
        {
            rigid.isKinematic = false;
        }

        mainCollider.enabled = false;
        MainRigidbody.isKinematic = true;
        StandUpAnimation.enabled = false;
    }

    void RagdollModeOff()
    {
        foreach(Collider col in RagdollColliders)
        {
            col.enabled = false;
        }

        foreach(Rigidbody rigid in  LimbsRigidBodies)
        {
            rigid.isKinematic = true;
        }

        mainCollider.enabled = true;
        MainRigidbody.isKinematic = false;
        StandUpAnimation.enabled = true;
    }

    IEnumerator FallOver()
    {
        yield return new WaitForSeconds(FallDelayTime);
        RagdollmodeOn();
    }

    
}
