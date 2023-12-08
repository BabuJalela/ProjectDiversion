using UnityEngine;

public class MainEntry : MonoBehaviour
{
    private GameManagerController gameManagerController;
    private LogController logController;

    private void Awake()
    {
        gameManagerController = new GameManagerController();
        gameManagerController?.RegisterListener();
        gameManagerController?.Initialize();
    }

    void Update()
    {
        gameManagerController?.Update();
    }
}
