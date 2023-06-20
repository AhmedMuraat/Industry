using RootMotion.Dynamics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackFlip : MonoBehaviour
{
    Animator Animator;
    public GameObject FullRig;
    public GameObject Target;
    public GameObject Target2;

    public float FallDelay = 0.5f;
    public float minJointHeight = 0.627f;
    public float maxJointHeight = 0.86f;
    GameObject[] JointsOff;
    GameObject[] JointsOn;
    public PuppetMaster puppetMaster;
    public string AnimationType;
    public string AnimationName;
    public LevelCompletion levelcompleted;
   //new

    List<GameObject> AllMoveableJoints = new List<GameObject>();
    public Material Highlighted;
    public Material NonHighlighted;
    public List<GameObject> Keyframe1 = new List<GameObject>();

    // Start is called before the first frame update
    public bool StartBackflip;
    void Start()
    {
        AllMoveableJoints = GameObject.FindGameObjectsWithTag("Moveable").ToList();

        //give all moveable joint the nonhighlighted material
        for (int i = 0; i < AllMoveableJoints.Count; i++)
        {
            AllMoveableJoints[i].GetComponent<Renderer>().material = NonHighlighted;

        }
        
        //give all moveable joint for the first keyframe the highlighted material
        for (int i = 0; i < Keyframe1.Count; i++)
        {
            Keyframe1[i].GetComponent<Renderer>().material = Highlighted;
        }

        Animator = GetComponent<Animator>();
        JointsOff = GameObject.FindGameObjectsWithTag("NonMoveable");
        JointsOn = GameObject.FindGameObjectsWithTag("Moveable");
    }
    void Update()
    {

    }



    void RagdollmodeOn()
    {
        Animator.enabled = false;

        puppetMaster.pinWeight = 0;
        puppetMaster.muscleWeight = 0f;
    }
    void Check1()
    {
        print("test");
        PauseAnimation();
        if (Target.transform.position.y > maxJointHeight || Target.transform.position.y < minJointHeight)
        {
            StartCoroutine(AnimationOff());
            Debug.Log("Bad posture");
            StartCoroutine(Failed());
        }
        else
        {
            ContinueAnimation();
        }

    }

    void Check2()
    {
        print("test");
        PauseAnimation();
    }

    void Check3()
    {
        print("test");
        PauseAnimation();
    }

    void Check4()
    {
        print("test");
        PauseAnimation();
    }

    void Check5()
    {
        print("test");
        PauseAnimation();
    }

    public void StartAnimation()
    {
        StartBackflip = true;
    }

    void PauseAnimation()
    {
        Animator.speed = 0f;
    }

    void ContinueAnimation()
    {
        Animator.speed = 1;
    }

    IEnumerator AnimationOff()
    {
        yield return new WaitForSeconds(FallDelay);
        print("Now");
        RagdollmodeOn();
    }

    IEnumerator Failed()
    {
        yield return new WaitForSeconds(2);

        levelcompleted.Failedscreen();
    }
    IEnumerator Succeed()
    {
        yield return new WaitForSeconds(2);

        levelcompleted.Completionscreen();
    }
}
