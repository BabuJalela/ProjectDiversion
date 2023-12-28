using UnityEngine;

public class GrabObjectToMove : MonoBehaviour
{
    private bool canHold = false;
    private bool keyPressed = false;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canHold)
        {
            keyPressed = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canHold = true;
        }
        if (keyPressed)
        {
            if (other.tag == "Crate")
            {
                return;
            }
            else
            {
                transform.SetParent(other.transform);
            }
            keyPressed = false;
            canHold = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canHold = false;
    }
}
