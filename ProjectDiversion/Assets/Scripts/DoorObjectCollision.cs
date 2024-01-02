using Events;
using UnityEngine;

public class DoorObjectCollision : MonoBehaviour
{
    private bool isTriggered = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cuboard" && !isTriggered)
        {
            GameEventManager.Instance.TriggerEvent(new DoorBlockEvent());
            isTriggered = true;
        }
    }
}
