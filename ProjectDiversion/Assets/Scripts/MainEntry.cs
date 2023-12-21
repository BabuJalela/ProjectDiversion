using UnityEngine;

public class MainEntry : MonoBehaviour
{
    private GameManagerController gameManagerController;

    private void Awake()
    {
        gameManagerController = new GameManagerController();
        gameManagerController?.RegisterListener();
        gameManagerController?.Initialize();
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        gameManagerController?.Update();
    }
    private void FixedUpdate()
    {
        gameManagerController?.FixedUpdate();
    }
}
