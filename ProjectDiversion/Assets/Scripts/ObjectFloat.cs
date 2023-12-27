using UnityEngine;

public class ObjectFloat : MonoBehaviour
{
    [SerializeField] private bool isFloat = false;
    private Transform waterInitialPoint;
    float angle = 0;
    // Start is called before the first frame update
    void Start()
    {
        waterInitialPoint = SpawnObjectAddressables.GetLevelDatathroughID("Water").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFloat)
        {
            if (transform.position.y != waterInitialPoint.position.y)
            {
                transform.position = new Vector3(transform.position.x, waterInitialPoint.position.y, transform.position.z);
            }
            if (this.gameObject != null)
            {
                ObjectFloatingAnim();
            }
        }

    }

    private void ObjectFloatingAnim()
    {
        angle += Time.deltaTime * 1.5f;
        float nosPosY = transform.position.y + Mathf.Sin(angle) * .2f;
        transform.position = new Vector3(transform.position.x, nosPosY, transform.position.z);
    }


}