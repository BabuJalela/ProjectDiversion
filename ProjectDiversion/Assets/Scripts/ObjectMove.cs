using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag == "Cuboard")
        {
            Rigidbody cuboardRB = hit.collider.attachedRigidbody;
            cuboardRB?.AddForce(transform.forward * 200);
            //SpawnObjectAddressables.GetLevelDatathroughID("Player").GetComponent<Animator>().SetBool("OnPush", true);
        }
        else
        {
            Rigidbody rb = hit.collider.attachedRigidbody;
            rb?.AddForce(transform.forward * Time.deltaTime * 200);

        }
    }

}
