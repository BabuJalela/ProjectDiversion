using StateMachine;
using UnityEngine;

public class PushState : State
{
    public override void OnEnter()
    {
        SpawnObjectAddressables.GetLevelDatathroughID("Player").GetComponent<Animator>().CrossFade("Push", 0.02f);
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate(float deltaTime)
    {

    }
}
