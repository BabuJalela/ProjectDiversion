using Events;

public class AddSceneController : GameEvent
{
    public IController controller;
    public AddSceneController(IController controller)
    {
        this.controller = controller;
    }
}

public class PrintLogEvent : GameEvent
{

}