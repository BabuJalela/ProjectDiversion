using Events;

public class AudioController : IController
{
    private Level2AudioManager level2AudioManager;
    public void Initialize()
    {
        level2AudioManager = new Level2AudioManager();
        level2AudioManager.OnStart();
    }

    public void RegisterListener()
    {
        GameEventManager.Instance.AddListener<LeverPullEvent>(LeverPull);
    }

    public void UnRegisterListener()
    {
        GameEventManager.Instance.RemoveListener<LeverPullEvent>(LeverPull);
    }

    public void FixedUpdate()
    {

    }
    public void Update()
    {
        level2AudioManager.OnUpdate();
    }

    #region LEVEL2 AUDIO MANAGER
    private void LeverPull(LeverPullEvent e)
    {
        level2AudioManager.OnLeverPull(e.canFill);
    }
    #endregion
}
