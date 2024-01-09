using Events;
using UnityEngine;

public class DoorObjectCollision : MonoBehaviour
{
    private bool isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cuboard" && !isTriggered)
        {
            GameEventManager.Instance.TriggerEvent(new DoorBlockEvent());
            isTriggered = true;
        }
    }
}
