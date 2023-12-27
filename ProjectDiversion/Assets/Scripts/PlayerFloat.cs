using UnityEngine;

public class PlayerFloat : MonoBehaviour
{
    [SerializeField]
    float buoyancy_force;
    [SerializeField] private Transform playerTransform;
    [SerializeField] Rigidbody rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SpawnObjectAddressables.GetLevelDatathroughID("Water").transform.position.y < transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, SpawnObjectAddressables.GetLevelDatathroughID("Water").transform.position.y, transform.position.z);

        }
    }
}
