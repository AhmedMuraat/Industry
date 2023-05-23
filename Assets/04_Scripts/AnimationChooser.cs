using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationChooser : MonoBehaviour
{
    Animator Animator;
    public GameObject FullRig;
    public GameObject Target;
    public string AnimationType;
    public string AnimationName;

    Collider[] RagdollColliders;
    Rigidbody[] LimbsRigidBodies;
    GameObject[] JointsOff;
    GameObject[] JointsOn;

    public float minJointHeight = 0.627f;
    public float maxJointHeight = 0.86f;

    public bool FirstCheck = true;
    public bool SecondCheck = false;

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
            if (FirstCheck)
            {
                Animator.SetTrigger(AnimationType);
                if (Target.transform.position.y > maxJointHeight || Target.transform.position.y < minJointHeight)
                {
                    StartCoroutine(AnimationOff());
                    Debug.Log("Bad posture");
                    Debug.Log(Target.transform.position.y);
                }
                else
                {
                    Debug.Log("Good posture");

                    StartCoroutine(PauseAnimation());
                }

                FirstCheck = false;
            }
            else if (SecondCheck)
            {
                Debug.Log(Target.transform.position.y);

                if (Target.transform.position.y < 1.3 || Target.transform.position.y > 1.4)
                {
                    Debug.Log("Bad posture");
                    Animator.enabled = false;
                    RagdollmodeOn();
                }
                else
                {
                    Debug.Log("Good posture");
                    Animator.speed = 1f;
                }
            }
            

            TurnOffJoints();

            

        }
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName(AnimationName))
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

    IEnumerator PauseAnimation()
    {
        yield return new WaitForSeconds(1.5f);
        SecondCheck = true;
        Animator.speed = 0f;

        TurnOnJoints();
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

    void TurnOnJoints()
    {
        foreach (GameObject obj in JointsOff)
        {
            obj.GetComponent<MeshRenderer>().enabled = true;
        }

        foreach (GameObject obj in JointsOn)
        {
            obj.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    public void StartAnimation()
    {
        StartStandingUp = true;
    }


}
