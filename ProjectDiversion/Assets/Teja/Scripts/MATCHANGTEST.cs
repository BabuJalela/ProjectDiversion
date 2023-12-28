using UnityEditor;
using UnityEngine;

public class MATCHANGTEST : MonoBehaviour
{

    public Material desiredMaterial;

    void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                
                MeshRenderer meshRenderer = hit.collider.GetComponent<MeshRenderer>();

                if (meshRenderer != null)
                {
                    
                    AddMaterial(meshRenderer);
                }
            }
        }
    }

    void AddMaterial(MeshRenderer meshRenderer)
    {
      
        Material[] newMaterials = new Material[meshRenderer.materials.Length + 1];
        for (int i = 0; i < meshRenderer.materials.Length; i++)
        {
            newMaterials[i] = meshRenderer.materials[i];
        }
        newMaterials[newMaterials.Length - 1] = desiredMaterial;

  
        meshRenderer.materials = newMaterials;
    }
    
   
}
