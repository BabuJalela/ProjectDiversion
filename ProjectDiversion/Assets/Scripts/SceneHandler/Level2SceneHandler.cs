using Events;
using System.Collections;
using UnityEngine;

public class Level2SceneHandler : SceneHandler
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private LevelData levelData;
    [SerializeField] private string levelID;
    protected override void Initialize()
    {
        AddSceneController(new LogController());
        AddSceneController(new PlayerStateMachine(playerData, levelData));
        AddSceneController(new PlayerController(playerData));
        AddSceneController(new UIController());
        AddSceneController(new Controllers.LevelController(levelID));
        AddSceneController(new AudioController());
        //StartCoroutine(Print());

    }

    IEnumerator Print()
    {
        yield return new WaitForSeconds(2f);
        GameEventManager.Instance.TriggerEvent(new PrintLogEvent());
    }
}
