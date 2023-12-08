using Events;
using System.Collections;
using UnityEngine;

public class MainSceneHandler : SceneHandler
{
    protected override void Initialize()
    {
        base.Initialize();

        AddSceneController(new LogController());
        StartCoroutine(Print());

    }

    IEnumerator Print()
    {
        yield return new WaitForSeconds(2f);
        GameEventManager.Instance.TriggerEvent(new PrintLogEvent());
    }
}
