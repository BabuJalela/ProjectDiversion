using Events;

public class LevelController : IController
{
    public void Initialize()
    {

    }

    public void RegisterListener()
    {
        GameEventManager.Instance.AddListener<LeverPullEvent>(OnLeverPull);
    }

    public void UnRegisterListener()
    {
        GameEventManager.Instance.RemoveListener<LeverPullEvent>(OnLeverPull);

    }

    public void FixedUpdate()
    {

    }


    public void Update()
    {

    }

    #region Level2
    private void OnLeverPull(LeverPullEvent e)
    {
        Level2Manager.OnLeverPull();
    }

    #endregion
}
