using StateMachine;
using UnityEngine;

public class LeverState : State
{
    public override void OnEnter()
    {
        SpawnObjectAddressables.GetLevelDatathroughID("Lever").GetComponent<Animator>().CrossFade("Lever Action", 0.02f);
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate(float deltaTime)
    {

    }

}
