using Events;
using TMPro;
using UnityEngine;

public class DoorOpenTrigger : MonoBehaviour
{
    [SerializeField] private TMP_Text DoorOpenText;
    [SerializeField] AudioClip openDoorClip;
    [SerializeField] AudioClip closeDoorClip;
    private AudioSource audioSource;
    private bool isOpen = false;
    private bool canClose = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isOpen)
        {
            DoorOpenText.gameObject.SetActive(false);
            if (canClose)
            {
                GameEventManager.Instance.TriggerEvent(new DoorOpenEvent(false));
                audioSource.PlayOneShot(closeDoorClip);
                isOpen = false;
            }
            else
            {
                GameEventManager.Instance.TriggerEvent(new DoorOpenEvent(true));
                audioSource.PlayOneShot(openDoorClip);
                canClose = true;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (isOpen)
        {
            return;
        }
        DoorOpenText.gameObject.SetActive(true);
        isOpen = true;
        canClose = false;
    }

    private void OnTriggerExit(Collider other)
    {
        DoorOpenText.gameObject.SetActive(false);
    }
}
