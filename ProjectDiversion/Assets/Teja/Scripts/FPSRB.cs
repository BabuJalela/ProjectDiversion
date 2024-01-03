using UnityEngine;

public class FPSRB : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mousesensitivity = 2f;
    public Camera plyayercamera;

    public void Start()
    {
        MovePlayer();
        RotatePlayer();
    }

    public void Update()
    {

    }

    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 moveAmount = moveDirection * movementSpeed * Time.deltaTime;

        transform.Translate(moveAmount);
    }
    void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X") * mousesensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mousesensitivity;

        transform.Rotate(Vector3.up * mouseX);

        //Camera mainCamera = Camera.main;
        if (plyayercamera != null)
        {
            Vector3 currentRotation = plyayercamera.transform.rotation.eulerAngles;
            float newRotationX = currentRotation.x - mouseY;
            plyayercamera.transform.rotation = Quaternion.Euler(newRotationX, currentRotation.y, currentRotation.z);
        }
    }
}
