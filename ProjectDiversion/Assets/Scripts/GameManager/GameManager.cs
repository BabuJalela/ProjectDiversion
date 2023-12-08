using System.Collections.Generic;

public class GameManager
{
    private List<IController> sceneControllers = new List<IController>();
    public void AddSceneController(IController controller)
    {
        controller.Initialize();
        controller.RegisterListener();
        sceneControllers.Add(controller);
    }

    public void UpdateControllers()
    {
        foreach (IController controller in sceneControllers)
        {
            controller.Update();
        }
    }


}
