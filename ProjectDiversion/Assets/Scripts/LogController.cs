using Events;

public class LogController : IController
{
    public void Initialize()
    {


    }

    public void RegisterListener()
    {
        GameEventManager.Instance.AddListener<PrintLogEvent>(PrintLog);
    }

    public void UnRegisterListener()
    {
        GameEventManager.Instance.RemoveListener<PrintLogEvent>(PrintLog);
    }

    public void Update()
    {

    }

    private void PrintLog(PrintLogEvent e)
    {
        UnityEngine.Debug.Log("MY CONTROLLER");
    }
}
