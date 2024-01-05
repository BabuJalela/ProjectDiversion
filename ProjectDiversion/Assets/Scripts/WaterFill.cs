using Events;
using UnityEditor.U2D;
using UnityEngine;

public class WaterFill : MonoBehaviour
{
    public bool IsFill { get => isFill; }
    [SerializeField] private float speed = 0.01f;
    [SerializeField] private bool isFill = false;
     public bool isValveOpen = false;
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
            transform.Translate(Vector3.up * speed * Time.fixedDeltaTime);
        }

        if (isValveOpen == true) 
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
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

