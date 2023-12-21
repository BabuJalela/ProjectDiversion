using Events;
using TMPro;
using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private TMP_Text leverText;
    private bool canPullLever = false;
    private bool isActive = false;
    private AudioSource audioSource;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canPullLever && !isActive)
        {
            animator.SetTrigger("isPlay");
            audioSource.PlayDelayed(0.5f);
            GameEventManager.Instance.TriggerEvent(new LeverPullEvent());
            leverText.gameObject.SetActive(false);
            canPullLever = false;
            isActive = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !isActive)
        {
            leverText.gameObject.SetActive(true);
            canPullLever = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        leverText.gameObject.SetActive(false);
    }

}
