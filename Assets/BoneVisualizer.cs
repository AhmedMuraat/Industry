using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneVisualizer : MonoBehaviour
{
    public GameObject boneVisualizationPrefab; // Reference to the bone visualization prefab
    public Transform characterRoot; // Root transform of the character rig
    public float boneVisualizationScale = 1f; // Scale factor for bone visualizations

    // Start is called before the first frame update
    void Start()
    {
        VisualizeSkeleton();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void VisualizeSkeleton()
    {
        // Traverse the bone hierarchy and visualize each bone
        TraverseBones(characterRoot, null);
    }

    private void TraverseBones(Transform currentBone, Transform parentVisualization)
    {
        // Instantiate a bone visualization object for the current bone
        GameObject boneVisualization = Instantiate(boneVisualizationPrefab, currentBone.position, currentBone.rotation);

        // Parent the bone visualization object to the parent visualization (if provided)
        if (parentVisualization != null)
        {
            boneVisualization.transform.SetParent(parentVisualization);
        }

        // Adjust the scale of the bone visualization
        boneVisualization.transform.localScale = Vector3.one * boneVisualizationScale;

        // Recursively visualize the child bones
        foreach (Transform childBone in currentBone)
        {
            TraverseBones(childBone, boneVisualization.transform);
        }
    }

}
