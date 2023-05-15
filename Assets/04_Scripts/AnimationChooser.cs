using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationChooser : MonoBehaviour
{
    Animator Animator;


    public bool StartStandingUp;
    bool IsPlaying;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StartStandingUp)
        {
            StartStandingUp = false;
            Animator.SetTrigger("StandUp2");

        }
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName("Stand Up"))
        {
            IsPlaying = false;
            StartStandingUp = false;

        }
    }

    
}
