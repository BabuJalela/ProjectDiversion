using UnityEngine;

public class DoorSlam : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private AudioSource audioSource;
    private bool isPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !isPlayed)
        {
            audioSource.Play();
            door.transform.localPosition = new Vector3(0, 0, 0);
            isPlayed = true;
        }
    }
}
