using Events;
using StateMachine;
using System.Collections.Generic;

public class PlayerStateMachine : BaseStateMachine, IController
{
    private Dictionary<string, State> playerStates;
    public PlayerStateMachine()
    {
        playerStates = new Dictionary<string, State>()
        {
            { StateIDs.PLAYERGROUNDSTATE, new PlayerGroundState() },
            { StateIDs.PLAYERWATERSTATE, new PlayerWaterState()}
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
