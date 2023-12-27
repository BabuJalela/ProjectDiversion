using Events;
using UnityEngine;

public class WaterFill : MonoBehaviour
{
    [SerializeField] private float speed = 0.05f;
    [SerializeField] private bool isFill = false;
    // Start is called before the first frame update

    private void OnEnable()
    {
        GameEventManager.Instance.AddListener<LeverPullEvent>(OnLeverPull);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFill)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

    }

    private void OnLeverPull(LeverPullEvent e)
    {
        isFill = e.canFill;
    }

    private void OnDisable()
    {
        GameEventManager.Instance.AddListener<LeverPullEvent>(OnLeverPull);
    }
}
