using Events;

public class GameManagerController : IController
{
    private GameManager gameManager;
    public void Initialize()
    {
        gameManager = new GameManager();
    }

    public void RegisterListener()
    {
        GameEventManager.Instance.AddListener<AddSceneController>(OnAddSceneControllerListener);

    }

    public void UnRegisterListener()
    {
        GameEventManager.Instance.RemoveListener<AddSceneController>(OnAddSceneControllerListener);

    }

    public void Update()
    {
        gameManager.UpdateControllers();
    }

    private void OnAddSceneControllerListener(AddSceneController e)
    {
        if (e == null || gameManager == null)
            return;
        gameManager.AddSceneController(e.controller);
    }


}
