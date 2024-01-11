using StateMachine;
using UnityEngine;

public class PlayerGroundState : State
{
    public override void OnEnter()
    {
        if (SpawnObjectAddressables.GetLevelDatathroughID("Player").TryGetComponent<Animator>(out var playerAnimator))
        {
            playerAnimator.CrossFade(StateIDs.PLAYERGROUNDSTATE, 0.02f);

        }
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate(float deltaTime)
    {

    }


}
