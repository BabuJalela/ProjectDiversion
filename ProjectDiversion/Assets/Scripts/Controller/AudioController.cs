using System.Collections.Generic;

public class AudioController : IController
{
    private BaseAudioManager activeAudioManager;
    private Dictionary<string, BaseAudioManager> audioManagers;
    private string levelID;

    public AudioController(string levelID)
    {
        audioManagers = new Dictionary<string, BaseAudioManager>()
        {
            {levelIDs.LEVEL2, new Level2AudioManager() }
        };
        this.levelID = levelID;
    }


    public void Initialize()
    {
        activeAudioManager = audioManagers[levelID];
        activeAudioManager.OnInitialize();
    }

    public void RegisterListener()
    {
        activeAudioManager.OnRegisterListener();
    }

    public void UnRegisterListener()
    {
        activeAudioManager.OnUnregisterListener();
    }

    public void FixedUpdate()
    {

    }
    public void Update()
    {
        activeAudioManager.OnUpdate();
    }
}
