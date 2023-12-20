using Events;

public class AudioController : IController
{
    private AudioManager audioManager;
    public void Initialize()
    {
        audioManager?.OnStart();
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
        audioManager?.OnUpdate();
    }

    #region LEVEL2 AUDIO MANAGER
    private void LeverPull(LeverPullEvent e)
    {
        Level2AudioManager.OnLeverPull();
    }
    #endregion
}
