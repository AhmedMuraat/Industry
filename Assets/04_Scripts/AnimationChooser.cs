using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChooser : MonoBehaviour
{
    Animator Animator;
    public GameObject FullRig;

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
    }

    void RagdollModeOff()
    {
        foreach (Collider col in RagdollColliders)
        {
            col.enabled = false;
        }

        foreach (Rigidbody rigid in LimbsRigidBodies)
        {
            rigid.isKinematic = true;
        }
    }


    public bool StartStandingUp;
    bool IsPlaying;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        GetRagdollElements();
        RagdollModeOff();
    }

    // Update is called once per frame
    void Update()
    {
        if (StartStandingUp)
        {
            StartStandingUp = false;
            Animator.SetTrigger("StandUp2");
            StartCoroutine(AnimationOff());

        }
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName("Stand Up"))
        {
            IsPlaying = false;
            StartStandingUp = false;

        }
    }

    IEnumerator AnimationOff()
    {
        yield return new WaitForSeconds(2f);
        Animator.enabled = false;
        RagdollmodeOn();
    }

    
}
