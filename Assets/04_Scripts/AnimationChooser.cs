using RootMotion.Dynamics;
using RootMotion.FinalIK;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AnimationChooser : MonoBehaviour
{
    Animator Animator;
    public GameObject FullRig;
    public GameObject Target;
    public GameObject Target2;
    public PuppetMaster puppetMaster;
    public string AnimationType;
    public string AnimationName;

    public GameObject Chair;
    Collider[] RagdollColliders;
    Rigidbody[] LimbsRigidBodies;
    GameObject[] JointsOff;
    GameObject[] JointsOn;

    public float minJointHeight = 0.627f;
    public float maxJointHeight = 0.86f;
    public float minJointHeightTarget2 = 1f;
    public float maxJointHeightTarget2 = 1.2f;
    public float minJointHeightCheck2 = 1.3f;
    public float maxJointHeightCheck2 = 1.4f;
    public float minJointHeightTarget2Check2 = 1f;
    public float maxJointHeightTarget2Check2 = 1.26f;
    public float FallDelay = 0.5f;
    public float KeyframeDelay = 1.5f;

    public bool FirstCheck = true;
    public bool SecondCheck = false;

    public LookAtIK lookAt1;
    public LookAtController lookAt1C;
    public LookAtIK lookAt2;
    public LookAtController lookAt2C;

    void GetRagdollElements()
    {
        RagdollColliders = FullRig.GetComponentsInChildren<Collider>();
        LimbsRigidBodies = FullRig.GetComponentsInChildren<Rigidbody>();
        JointsOff = GameObject.FindGameObjectsWithTag("NonMoveable");
        JointsOn = GameObject.FindGameObjectsWithTag("Moveable");
    }

    void RagdollmodeOn()
    {
        Animator.enabled = false;

        puppetMaster.pinWeight = 0;
        puppetMaster.muscleWeight = 0f;
        if (Chair is not null)
            Chair.GetComponent<MeshCollider>().enabled = true;

        //foreach (Collider col in RagdollColliders)
        //{
        //    col.enabled = true;
        //}

        //foreach (Rigidbody rigid in LimbsRigidBodies)
        //{
        //    rigid.isKinematic = false;
        //}
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
                    Debug.Log(Target2.transform.position.y);
                }
                else
                {
                    if (gameObject.tag == "2Joints")
                    {
                        if (Target2.transform.position.y > maxJointHeightTarget2 || Target2.transform.position.y < minJointHeightTarget2)
                        {
                            StartCoroutine(AnimationOff());
                            Debug.Log("Bad posture");
                            Debug.Log(Target2.transform.position.y);
                        }
                        else
                        {
                            Debug.Log("Good posture");

                            StartCoroutine(PauseAnimation());
                            Debug.Log(Target2.transform.position.y);
                        }
                    }
                    else
                    {
                        print("1 joint in this level");

                        Debug.Log("Good posture");

                        StartCoroutine(PauseAnimation());
                    }
                }

                FirstCheck = false;
            }
            else if (SecondCheck)
            {
                Debug.Log(Target.transform.position.y);

                if (Target.transform.position.y < minJointHeightCheck2 || Target.transform.position.y > maxJointHeightCheck2)
                {
                    Debug.Log("Bad posture");
                    Animator.enabled = false;
                    RagdollmodeOn();
                }
                else
                {
                    if (gameObject.tag == "2Joints")
                    {
                        if (Target2.transform.position.y < minJointHeightTarget2Check2 || Target2.transform.position.y > maxJointHeightTarget2Check2)
                        {
                            Debug.Log("Bad posture");
                            //print(Target2.transform.position.y);
                            Animator.enabled = false;
                            RagdollmodeOn();
                        }
                        else
                        {
                            Debug.Log("Good posture");
                            Animator.speed = 1f;
                            gameObject.GetComponent<RigBuilder>().enabled = false;
                        }
                    }
                    else
                    {
                        End();

                        Debug.Log("Good posture");

                    }
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
    void End()
    {
        Animator.speed = 1f;
        Animator.SetTrigger("Done");
        lookAt1.enabled = false;
        lookAt1C.enabled = false;
        lookAt2.enabled = false;
        lookAt2C.enabled = false;

    }
    IEnumerator AnimationOff()
    {
        yield return new WaitForSeconds(FallDelay);
        print("Now");
        RagdollmodeOn();
    }

    IEnumerator PauseAnimation()
    {
        yield return new WaitForSeconds(KeyframeDelay);

        SecondCheck = true;
        Animator.speed = 0f;

        TurnOnJoints();
    }

    void TurnOffJoints()
    {
        foreach (GameObject obj in JointsOff)
        {
            obj.GetComponent<MeshRenderer>().enabled = false;
        }

        foreach (GameObject obj in JointsOn)
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
