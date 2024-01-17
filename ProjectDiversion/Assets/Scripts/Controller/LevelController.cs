using System.Collections.Generic;
public class LevelController : IController
{
    private BaseLevelManager activeLevelManager;
    private Dictionary<string, BaseLevelManager> levelManagers;
    private string levelID;
    public LevelController(string levelID)
    {
        levelManagers = new Dictionary<string, BaseLevelManager>()
            {
                { levelIDs.LEVEL2, new Level2Manager()}

            };
        this.levelID = levelID;
    }
    public void Initialize()
    {
        activeLevelManager = levelManagers[levelID];
        activeLevelManager.OnInitialize();
    }

    public void RegisterListener()
    {
        activeLevelManager.OnRegisterListener();
    }

    public void UnRegisterListener()
    {
        activeLevelManager.OnUnregisterListener();
    }
    public void FixedUpdate()
    {

    }

    public void Update()
    {
        activeLevelManager.OnUpdate();
    }
}