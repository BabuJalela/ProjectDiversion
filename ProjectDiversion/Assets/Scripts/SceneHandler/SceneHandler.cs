using Events;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    private void Awake()
    {

    }

    private void Start()
    {
        Initialize();
    }


    // Update is called once per frame
    void Update()
    {

    }

    protected void AddSceneController(IController controller)
    {
        if (controller == null)
            return;

        GameEventManager.Instance.TriggerEvent(new AddSceneController(controller));
    }

    protected virtual void Initialize() { }
}
