using StateMachine;

public class PlayerIdleState : State
{
    PlayerData playerData;

    public PlayerIdleState(PlayerData playerData)
    {
        this.playerData = playerData;
    }
    public override void OnEnter()
    {
        playerData.playerAnimator.CrossFade("Idle", 0.02f);
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate(float deltaTime)
    {

    }

}
