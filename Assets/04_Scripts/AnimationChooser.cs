using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationChooser : MonoBehaviour
{
    Animator Animator;
    public GameObject FullRig;
    public GameObject Target;

    Collider[] RagdollColliders;
    Rigidbody[] LimbsRigidBodies;
    GameObject[] JointsOff;
    GameObject[] JointsOn;

    void GetRagdollElements()
    {
        RagdollColliders = FullRig.GetComponentsInChildren<Collider>();
        LimbsRigidBodies = FullRig.GetComponentsInChildren<Rigidbody>();
        JointsOff = FindObjectsOfType<GameObject>();
        JointsOff = System.Array.FindAll(JointsOff, obj => obj.layer == LayerMask.NameToLayer("MuscleOff"));
        JointsOn = FindObjectsOfType<GameObject>();
        JointsOn = System.Array.FindAll(JointsOn, obj => obj.layer == LayerMask.NameToLayer("Muscle"));
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

            if (col.gameObject.tag == "Moveable")
            {
                col.enabled = true;
            }
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
            if (Target.transform.position.y < 1.002 || Target.transform.position.y > 1.195)
            {
                StartCoroutine(AnimationOff());
                Debug.Log("Bad posture");
            }
            else
            {
                Debug.Log("Good posture");
            }

            TurnOffJoints();

            Debug.Log(Target.transform.position.y);

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

    void TurnOffJoints()
    {
        foreach( GameObject obj in JointsOff)
        {
            obj.GetComponent<MeshRenderer>().enabled = false;
        }

        foreach ( GameObject obj in JointsOn)
        {
            obj.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    
}
