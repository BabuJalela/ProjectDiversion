using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public DoorRotation rt;

    public Transform targetObject;
    public Transform referenceObject;

    public float rotationSpeed = 100f;
    public float threshold = 0.970f;

    [SerializeField] private GameObject PlayerCam;
    [SerializeField] private GameObject ObjCam;

    void Update()
    {
        puzzleControls();
    }

    public void puzzleControls()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");

        float angleSpeed = rotationSpeed * Time.deltaTime;

        Quaternion mouseRotation = Quaternion.AngleAxis(angleSpeed * mouseX, referenceObject.up) * Quaternion.AngleAxis(angleSpeed * mouseY, referenceObject.right);
        transform.rotation = mouseRotation * transform.rotation;

        float dotUp = Vector3.Dot(transform.up, targetObject.up);
        float dotRight = Vector3.Dot(transform.right, targetObject.right);

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (dotRight >= threshold && dotUp >= threshold)
            {
                rt.yesRotate();
                PlayerCam.SetActive(true);
                ObjCam.SetActive(false);
            }
            else
            {
                rt.noRotate();
            }
        }
    }
}
