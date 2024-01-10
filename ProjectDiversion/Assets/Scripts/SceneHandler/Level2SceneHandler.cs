using UnityEngine;

public class Level2SceneHandler : SceneHandler
{
    [SerializeField] private string levelID;
    protected override void Initialize()
    {
        AddSceneController(new LevelController(levelID));
        AddSceneController(new AudioController());

    }
}
