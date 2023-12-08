using Events;
using System.Collections;
using UnityEngine;

public class MainSceneHandler : SceneHandler
{
    protected override void Initialize()
    {
        base.Initialize();

        AddSceneController(new LogController());
        AddSceneController(new PlayerStateMachine());
        StartCoroutine(Print());

    }

    IEnumerator Print()
    {
        yield return new WaitForSeconds(2f);
        GameEventManager.Instance.TriggerEvent(new PrintLogEvent());
    }
}
