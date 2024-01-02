using Events;

public class LevelController : IController
{
    Level2Manager level2Manager;
    public void Initialize()
    {
        level2Manager = new Level2Manager();
        level2Manager.OnStart();
    }

    public void RegisterListener()
    {
        GameEventManager.Instance.AddListener<LeverPullEvent>(OnLeverPull);
        GameEventManager.Instance.AddListener<DoorBlockEvent>(OnDoorBlock);
    }

    public void UnRegisterListener()
    {
        GameEventManager.Instance.RemoveListener<LeverPullEvent>(OnLeverPull);
        GameEventManager.Instance.RemoveListener<DoorBlockEvent>(OnDoorBlock);

    }

    public void FixedUpdate()
    {

    }


    public void Update()
    {
        level2Manager.OnUpdate();
    }

    #region Level2
    private void OnLeverPull(LeverPullEvent e)
    {
        level2Manager.OnLeverPull(e.canFill);
    }

    private void OnDoorBlock(DoorBlockEvent e)
    {
        level2Manager.isDoorBlocked = true;
    }

    #endregion
}
