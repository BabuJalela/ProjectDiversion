using UnityEditor;
using UnityEngine;

public class MATCHANGTEST : MonoBehaviour
{

    public Material desiredMaterial; // Assign the desired material in the Inspector

    void Update()
    {
        // Check for mouse click or touch input
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the screen point where the mouse click or touch occurred
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Perform the raycast
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // Check if the object hit has a MeshRenderer
                MeshRenderer meshRenderer = hit.collider.GetComponent<MeshRenderer>();

                if (meshRenderer != null)
                {
                    // Add the desired material to the material list
                    AddMaterial(meshRenderer);
                }
            }
        }
    }

    void AddMaterial(MeshRenderer meshRenderer)
    {
        // Clone the existing materials array and add the desired material
        Material[] newMaterials = new Material[meshRenderer.materials.Length + 1];
        for (int i = 0; i < meshRenderer.materials.Length; i++)
        {
            newMaterials[i] = meshRenderer.materials[i];
        }
        newMaterials[newMaterials.Length - 1] = desiredMaterial;

        // Assign the new materials array to the MeshRenderer
        meshRenderer.materials = newMaterials;
    }
    //public Material outlinemat;
    //private Renderer objectrender;

    //private void Start()
    //{
    //    objectrender = GetComponent<Renderer>();
    //}

    //private void Update()
    //{
    //    handelmateraltoglinput();
    //}

    //void handelmateraltoglinput()
    //{
    //    if (Input.GetKeyDown(KeyCode.H))
    //    {
    //        togglematerial();
    //    }
    //}

    //private void togglematerial()
    //{
    //    if (outlinemat != null && objectrender != null)
    //    {
    //        Material[] materials = objectrender.materials;
    //        ArrayUtility.Add(ref materials, outlinemat);
    //        objectrender.materials = materials;
    //    }
    //}


}
