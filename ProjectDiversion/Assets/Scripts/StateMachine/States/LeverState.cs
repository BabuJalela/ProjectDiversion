using StateMachine;
using UnityEngine;

public class LeverState : State
{
    LevelData levelData;
    public LeverState(LevelData levelData)
    {
        this.levelData = levelData;
    }
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
