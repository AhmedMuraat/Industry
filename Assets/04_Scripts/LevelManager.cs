using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public bool IsPaused;

    public Material Surfice;
    public Material Joint;
    public Material SurficeTransparant;
    public Material JointTransparant;

    public SkinnedMeshRenderer BodyMesh;
    public SkinnedMeshRenderer JointMesh;

    public AnimationChooser animationChooser;
    // Start is called before the first frame update
    void Start()
    {
        IsPaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsPaused)
        {
            BodyMesh.material = SurficeTransparant;
            JointMesh.material = JointTransparant;
        }
        else
        {
            BodyMesh.material = Surfice;
            JointMesh.material = Joint;
        }
    }

    public void StartLevel()
    {
        IsPaused = false;
        animationChooser.StartStandingUp = true;

    }
}
