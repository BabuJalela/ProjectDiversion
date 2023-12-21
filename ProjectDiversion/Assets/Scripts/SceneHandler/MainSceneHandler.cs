using Events;
using System.Collections;
using UnityEngine;

public class MainSceneHandler : SceneHandler
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private LevelData levelData;

    protected override void Initialize()
    {
        base.Initialize();

        AddSceneController(new LogController());
        AddSceneController(new PlayerStateMachine(playerData, levelData));
        AddSceneController(new PlayerController(playerData));
        AddSceneController(new UIController());
        AddSceneController(new LevelController());
        AddSceneController(new AudioController());
        StartCoroutine(Print());

    }

    IEnumerator Print()
    {
        yield return new WaitForSeconds(2f);
        GameEventManager.Instance.TriggerEvent(new PrintLogEvent());
    }
}
