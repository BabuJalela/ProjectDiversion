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

public class ChangePlayerStateEvent : GameEvent
{
    public string stateID;

    public ChangePlayerStateEvent(string stateID)
    {
        this.stateID = stateID;
    }
}

public class LeverPullEvent : GameEvent
{

}
public class FollowWaterLevelEvent : GameEvent
{

}

public class DoorOpenEvent : GameEvent
{
    public bool isDoorOpen = false;
    public DoorOpenEvent(bool isDoorOpen)
    {
        this.isDoorOpen = isDoorOpen;
    }
}