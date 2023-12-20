using Events;
using StateMachine;
using System.Collections.Generic;

public class PlayerStateMachine : BaseStateMachine, IController
{
    private Dictionary<string, State> playerStates;
    private PlayerData playerData;
    public PlayerStateMachine(PlayerData playerData, LevelData levelData)
    {
        this.playerData = playerData;
        playerStates = new Dictionary<string, State>()
        {
            { StateIDs.IDLESTATE, new PlayerIdleState(playerData) },
            { StateIDs.RUNSTATE, new PlayerRunState(playerData)},
            { StateIDs.LEVERSTATE, new LeverState(levelData) }
        };
    }
    public void Initialize()
    {

    }

    public void RegisterListener()
    {
        GameEventManager.Instance.AddListener<ChangePlayerStateEvent>(ChangePlayerState);
    }

    public void UnRegisterListener()
    {
        GameEventManager.Instance.RemoveListener<ChangePlayerStateEvent>(ChangePlayerState);
    }


    void IController.Update()
    {
        base.Update();
    }

    private void ChangePlayerState(ChangePlayerStateEvent e)
    {
        base.ChangeState(playerStates[e.stateID]);
    }

    public void FixedUpdate()
    {

    }
}
