using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public Transform PickUp(Transform holder)
    {
        rb.isKinematic = true;
        rb.detectCollisions = false;

        transform.SetParent(holder);
        return transform;
    }

    public void OnPickUp()
    {
        Debug.Log("Picked up: " + gameObject.name);
    }

    public void OnDrop()
    {
        rb.isKinematic = false;
        rb.detectCollisions = true;

        transform.SetParent(null);
    }
}
