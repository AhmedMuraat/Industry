using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneVisualizer : MonoBehaviour
{
    public float lineThickness = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnRenderObject()
    {
        RenderBoneHierarchy();
    }

    private void RenderBoneHierarchy()
    {
        Transform[] bones = GetComponentInChildren<SkinnedMeshRenderer>().bones;

        

        GL.Begin(GL.LINES);
        GL.Color(Color.blue);

        for (int i = 0; i < bones.Length; i++)
        {
            if (bones[i].parent != null)
            {
                // Render line between current bone and its parent bone
                GL.Vertex(bones[i].position);
                GL.Vertex(bones[i].parent.position);
            }
        }

        GL.End();
    }

}
