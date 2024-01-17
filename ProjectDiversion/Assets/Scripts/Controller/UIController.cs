using System.Collections.Generic;

public class UIController : IController
{

    private BaseUIManager activeUIManager;
    private Dictionary<string, BaseUIManager> uiManagers;
    private string levelID;
    public UIController(string levelID)
    {
        uiManagers = new Dictionary<string, BaseUIManager>()
        {
            {levelIDs.LEVEL2, new Level2UIManager() }
        };
        this.levelID = levelID;
    }
    public void Initialize()
    {
        activeUIManager = uiManagers[levelID];
        activeUIManager.OnInitialize();
    }

    public void RegisterListener()
    {
        activeUIManager.OnRegisterListener();
    }

    public void UnRegisterListener()
    {
        activeUIManager.OnUnregisterListener();
    }

    public void FixedUpdate()
    {

    }
    public void Update()
    {
        activeUIManager.OnUpdate();
    }
}
