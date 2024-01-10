using UnityEngine;

public class ObjectFloat : MonoBehaviour
{
    [SerializeField] private bool isFloat = false;
    [SerializeField] Transform floatingPoint;
    [SerializeField] Movements movements;
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
        if (waterInitialPoint.transform.position.y > floatingPoint.transform.position.y && !isFloat)
        {
            isFloat = true;
            movements.inWater = true;
        }
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
        angle += Time.deltaTime * 1.2f;
        float nosPosY = transform.position.y + Mathf.Sin(angle) * .05f;
        transform.position = new Vector3(transform.position.x, nosPosY - 1.2f, transform.position.z);
    }


}