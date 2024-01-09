using Cinemachine;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    private CinemachineVirtualCamera playerCam;
    private bool canGrab = false;
    // Start is called before the first frame update
    void Start()
    {
        playerCam = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizonatalAxis = Input.GetAxis("Horizontal") * Time.deltaTime * 50;
        float verticalAxis = Input.GetAxis("Vertical") * Time.deltaTime * 5;

        transform.Translate(0, 0, verticalAxis);
        transform.Rotate(0, horizonatalAxis, 0);
        ObjectPickUp();
    }

    private void ObjectPickUp()
    {
        Debug.DrawRay(transform.position, playerCam.transform.forward * 5, Color.blue);
        if (Physics.Raycast(transform.position, playerCam.transform.forward, out RaycastHit hit, 5, layerMask))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                canGrab = !canGrab;
            }

            if (canGrab)
            {
                hit.transform.SetParent(transform);
            }
            else
            {
                hit.transform.SetParent(null);
            }
        }
    }
}
