using RootMotion.Dynamics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BackFlip : MonoBehaviour
{
    //new
    Animator Animator;
    public PuppetMaster puppetMaster;
    public LevelCompletion LevelCompletedScript;
    [Header("Sliders")]
    public Slider LeftSlider;
    public Slider RightSlider;

    public Material LeftHighlighted;
    public Material RightHighlighted;
    public Material NonHighlighted;
    public List<JointInfo> Keyframe1 = new List<JointInfo>();
    public List<JointInfo> Keyframe2 = new List<JointInfo>();
    int CurrentKeyframeID = 0;

    List<GameObject> AllMoveableJoints = new List<GameObject>();

    void Start()
    {
        AllMoveableJoints = GameObject.FindGameObjectsWithTag("Moveable").ToList();
        Animator = GetComponent<Animator>();

        //give all moveable joint the nonhighlighted material
        for (int i = 0; i < AllMoveableJoints.Count; i++)
        {
            AllMoveableJoints[i].GetComponent<Renderer>().material = NonHighlighted;

        }

        Animator.speed = 0.5f;
        Animator.SetTrigger("Start");
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
        SetColorForJoint(Keyframe1);
        SetSlidersNewTargets(Keyframe1);
    }
    void SetSlidersNewTargets(List<JointInfo> joints)
    {
        SliderMusleMover LeftsliderMusleMover = LeftSlider.gameObject.GetComponent<SliderMusleMover>();
        SliderMusleMover RightsliderMusleMover = RightSlider.gameObject.GetComponent<SliderMusleMover>();
        LeftsliderMusleMover.Target.Clear();
        RightsliderMusleMover.Target.Clear();

        for (int i = 0; i < joints.Count; i++)
        {
            if (joints[i].direction == JointInfo.Direction.Left)
            {
                LeftSlider.value = joints[i].TargetStartingPoint;

                LeftSlider.minValue = joints[i].TargetMinHeight;
                LeftSlider.maxValue = joints[i].TargetMaxHeight;
                LeftsliderMusleMover.Target.Add(joints[i].Target);
            }
            else
            {
                RightSlider.value = joints[i].TargetStartingPoint;

                RightSlider.minValue = joints[i].TargetMinHeight;
                RightSlider.maxValue = joints[i].TargetMaxHeight;
                RightsliderMusleMover.Target.Add(joints[i].Target);

            }
        }

    }
    public void StartAnimation()
    {
        switch (CurrentKeyframeID)
        {
            case 0:
                CheckRules(Keyframe1, true);
                break;
            case 1:
                CheckRules(Keyframe1, false);
                break;
            case 2:
                CheckRules(Keyframe1, false);
                break;
            case 3:
                CheckRules(Keyframe1, false);
                break;
        }
        CurrentKeyframeID++;
        Animator.speed = 0.5f;
    }
    void CheckRules(List<JointInfo> joints, bool check)
    {
        if (!check)
            return;

        for (int i = 0; i < joints.Count; i++)
        {
            if (!(joints[i].Target.transform.position.y >= joints[i].MinHeight && joints[i].Target.transform.position.y <= joints[i].MaxHeight))
            {
                //dead
                RagdollmodeOn();
            }
        }
    }

    void SetColorForJoint(List<JointInfo> joints)
    {
        for (int i = 0; i < AllMoveableJoints.Count; i++)
        {
            AllMoveableJoints[i].GetComponent<Renderer>().material = NonHighlighted;

        }

        foreach (JointInfo joint in joints)
        {
            if (joint.direction == JointInfo.Direction.Right)
            {
                joint.Joint.GetComponent<Renderer>().material = RightHighlighted;
            }
            else
            {
                joint.Joint.GetComponent<Renderer>().material = LeftHighlighted;
            }
        }
    }

    void Check2()
    {
        print("test");
        PauseAnimation();
        SetColorForJoint(Keyframe2);
        SetSlidersNewTargets(Keyframe2);
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

    void PauseAnimation()
    {
        Animator.speed = 0f;
    }

    void ContinueAnimation()
    {
        Animator.speed = 1;
    }



    IEnumerator Failed()
    {
        yield return new WaitForSeconds(2);

        LevelCompletedScript.Failedscreen();
    }
    IEnumerator Succeed()
    {
        yield return new WaitForSeconds(2);

        LevelCompletedScript.Completionscreen();
    }
}

[System.Serializable]
public class JointInfo
{
    public GameObject Joint;
    public Direction direction;
    public GameObject Target;
    public float TargetStartingPoint;
    public float TargetMinHeight;
    public float TargetMaxHeight;
    [Header("Allowed Rules")]
    public float MinHeight;
    public float MaxHeight;
    public enum Direction
    {
        Left,
        Right
    }

}
