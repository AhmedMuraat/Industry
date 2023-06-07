using RootMotion.Dynamics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackFlip : MonoBehaviour
{
    Animator Animator;
    public GameObject FullRig;
    public GameObject Target;
    public GameObject Target2;
    public PuppetMaster puppetMaster;
    public string AnimationType;
    public string AnimationName;
    
    // Start is called before the first frame update
    public bool StartBackflip;
    void Start()
    {
        Animator = GetComponent<Animator>();
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
}
