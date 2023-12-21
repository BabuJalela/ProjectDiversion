using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public float interactionRange = 3f; 
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
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, interactionRange, interactableLayer))
        {
            InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();
            if (interactable != null)
            {
                carriedObject = interactable.PickUp(transform);

                interactable.OnPickUp();
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
