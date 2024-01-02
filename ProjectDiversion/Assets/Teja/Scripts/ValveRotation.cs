using UnityEngine;

public class ValveRotation : MonoBehaviour
{
    public float raotationSpeed = 10f;
    private bool IsvalveOpened = false;
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                RotateValve();
            }

            if (IsvalveOpened)
            {
                Debug.Log("Valve opened");
            }
        }
    }

    void RotateValve()
    {
        transform.Rotate(Vector3.up, raotationSpeed * Time.deltaTime);

        if (transform.rotation.eulerAngles.y >= 90f)
        {
            IsvalveOpened=true;
        }

    }
}
