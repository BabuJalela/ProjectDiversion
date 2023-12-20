public class PlayerController : IController
{
    private PlayerData playerData;
    private PlayerManager playerManager;
    public PlayerController(PlayerData playerData)
    {
        this.playerData = playerData;
        playerManager = new PlayerManager(playerData);
    }


    public void Initialize()
    {
        playerManager.OnStart();
    }

    public void RegisterListener()
    {

    }

    public void UnRegisterListener()
    {

    }
    public void FixedUpdate()
    {
    }

    public void Update()
    {
        playerManager.OnUpdate();

    }
}
