using Events;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private Vector3 finalPosition;
    private Quaternion initialRotation;
    private bool canOpen = false;
    private bool canClose = false;
    // Start is called before the first frame update

    private void OnEnable()
    {
        GameEventManager.Instance.AddListener<DoorOpenEvent>(OnDoorTrigger);
    }
    void Start()
    {
        initialRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(finalPosition), Time.deltaTime * 2f);
        }
        if (canClose)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, initialRotation, Time.deltaTime * 2f);
        }
    }
    private void OnDoorTrigger(DoorOpenEvent e)
    {
        canOpen = e.isDoorOpen;
        canClose = !e.isDoorOpen;
    }

    private void OnDisable()
    {
        GameEventManager.Instance.RemoveListener<DoorOpenEvent>(OnDoorTrigger);
    }
}
