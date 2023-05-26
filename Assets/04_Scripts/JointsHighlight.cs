using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class JointsHighlight : MonoBehaviour
{
    public LayerMask layerMask;
    public Material originalMaterial;
    public Material highlightMaterial;
    public MuscleMover[] muscleMover;

    public float blinkDuration = 5f;

    public float highlightDuration = 1f;

    private Renderer sphereRenderer;
    float elapsedTime = 0f;

    void Start()
    {
        // Populate the allSpheres list with the sphere game objects in your ragdoll
        sphereRenderer = GetComponent<Renderer>();
        // Store the original color

        StartCoroutine(BlinkCoroutine());

    }

    void Update()
    {
        // Check for mouse click
        //if (Input.GetMouseButtonDown(0))
        //{
        //    // Handle mouse click
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit, 1000, layerMask))
        //    {
        //        Debug.Log("Shoot: " + hit.collider.tag);

        //        // Check if the ray hit a sphere
        //        if (hit.collider.gameObject.tag == "Moveable")
        //        {
        //            Debug.Log("Clicked");
        //            HighlightSphere(hit.collider.gameObject);
        //        }
        //        else
        //        {
        //            // No sphere was clicked, remove any highlights
        //            Debug.Log("No sphere clicked");
        //            RemoveHighlight();
        //        }
        //    }
        //    else
        //    {
        //        Debug.Log("No sphere clicked");
        //        // Mouse click was outside the sphere, remove the highlight
        //        RemoveHighlight();
        //    }
        //}

        for (int i = 0; i < muscleMover.Length; i++)
        {
            if (muscleMover[i].isHolding)
            {
                HighlightSphere(muscleMover[i].gameObject);
            }
            else
            {
                RemoveHighlight();
            }
        }
        elapsedTime += Time.deltaTime;

    }


    void HighlightSphere(GameObject sphere)
    {
        // Change the color or material of the clicked sphere to indicate the highlight
        Renderer renderer = sphere.GetComponent<Renderer>();
        renderer.material = highlightMaterial;

        Debug.Log("hightlight sphere");
    }

    void HighlightSphere()
    {
        // Change the sphere color to the highlight color
        sphereRenderer.material = highlightMaterial;
        Debug.Log("hightlight sphere");
    }

    void RemoveHighlight()
    {
        GameObject[] spheres = GameObject.FindGameObjectsWithTag("Moveable");
        foreach (GameObject sphere in spheres)
        {
            Renderer renderer = sphere.GetComponent<Renderer>();
            renderer.material = originalMaterial;
        }
        Debug.Log("return to orignal color");
    }

    IEnumerator BlinkCoroutine()
    {
        bool isHighlighted = false;

        while (elapsedTime < blinkDuration)
        {
            if (isHighlighted)
            {
                HighlightSphere();
                yield return new WaitForSeconds(highlightDuration);
            }
            else
            {
                RemoveHighlight();
                yield return new WaitForSeconds(1); // Interval between blinks
            }

            isHighlighted = !isHighlighted;
        }

        // Ensure the sphere ends with the original color
        RemoveHighlight();
    }

}