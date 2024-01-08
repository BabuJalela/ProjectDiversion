using UnityEngine;

public class PlayerFloat : MonoBehaviour
{
    [SerializeField] private float boyancyForce;
    private GameObject floatingPlane;
    private Movements movementComponent;
    private bool canFloat = false;

    Vector3 offset;
    WaterFill waterfill;

    // Start is called before the first frame update
    void Start()
    {
        waterfill = GetComponent<WaterFill>();
        floatingPlane = SpawnObjectAddressables.GetLevelDatathroughID("FloatingPlane");
        movementComponent = SpawnObjectAddressables.GetLevelDatathroughID("Player").GetComponent<Movements>();
        offset = floatingPlane.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (waterfill != null && waterfill.IsFill)
        {
            if (transform.position.y > movementComponent.floatPoint.transform.position.y)
            {
                if (canFloat)
                    return;

                movementComponent.transform.GetComponent<Animator>().SetBool("InWater", true);
                canFloat = true;
            }
        }*/

    }

    private void FixedUpdate()
    {
        if (waterfill != null && waterfill.IsFill)
        {
            floatingPlane.transform.position = new Vector3(movementComponent.transform.position.x, transform.position.y + offset.y, movementComponent.transform.position.z);
            movementComponent.inWater = true;
            //if (canFloat)
            //{
            //    OnPlayerFloat();
            //}
        }
    }


    public void OnPlayerFloat()
    {

    }

}
