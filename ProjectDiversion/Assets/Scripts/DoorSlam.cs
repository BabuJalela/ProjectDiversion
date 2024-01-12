using UnityEngine;

public class DoorSlam : MonoBehaviour
{
    [SerializeField] private GameObject door;
    private AudioSource audioSource;
    private bool isPlayed = false;
    [SerializeField] private GameObject exitCam;
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
            SpawnObjectAddressables.GetLevelDatathroughID(level2SpawnedObjectIDs.PLAYER).GetComponent<Movements>().stopPlayerMove = true;
            Invoke(nameof(ExitCamActive), 2f);
            isPlayed = true;
        }
    }

    private void ExitCamActive()
    {
        exitCam?.SetActive(true);

    }
}
