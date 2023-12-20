using StateMachine;

public class PlayerRunState : State
{
    PlayerData playerData;

    public PlayerRunState(PlayerData playerData)
    {
        this.playerData = playerData;
    }
    public override void OnEnter()
    {
        playerData.playerAnimator.CrossFade("Walk", 0.02f);
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate(float deltaTime)
    {

    }
}
