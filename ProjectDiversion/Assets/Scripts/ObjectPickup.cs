using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] private Transform playerCam;
    private bool canGrab = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ObjectPickUp();
    }

    private void ObjectPickUp()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Debug.DrawRay(ray.origin, ray.direction.normalized * 4, Color.blue);
        if (Physics.Raycast(ray, out RaycastHit hit, 4, layerMask))
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                canGrab = !canGrab;
                if (canGrab)
                {
                    hit.transform.GetComponent<Rigidbody>().isKinematic = true;
                    hit.transform.SetParent(Camera.main.transform);
                }
                else
                {
                    hit.transform.SetParent(null);
                    hit.transform.GetComponent<Rigidbody>().isKinematic = false;
                }
            }

        }

    }
}
