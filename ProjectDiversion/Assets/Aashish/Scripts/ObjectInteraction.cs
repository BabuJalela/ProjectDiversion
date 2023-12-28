using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public float interactionRadius = 3f; 
    public LayerMask interactableLayer; 

    private Transform carriedObject; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (carriedObject == null)
            {
                TryPickUpObject();
            }
            else
            {
                DropObject();
            }
        }
    }

    void TryPickUpObject()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, interactionRadius, interactableLayer);
        foreach (Collider collider in colliders)
        {
            InteractableObject interactable = collider.GetComponent<InteractableObject>();
            if (interactable != null)
            {
                carriedObject = interactable.PickUp(transform);

                interactable.OnPickUp();

                break;
            }
        }
    }

    void DropObject()
    {
        if (carriedObject != null)
        {
            carriedObject.position = transform.position;

            InteractableObject interactable = carriedObject.GetComponent<InteractableObject>();
            if (interactable != null)
            {
                interactable.OnDrop();
            }

            carriedObject = null;
        }
    }
}
