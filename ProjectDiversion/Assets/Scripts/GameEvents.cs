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
    public bool canFill = false;

    public LeverPullEvent(bool canFill = false)
    {
        this.canFill = canFill;
    }
}
public class FollowWaterLevelEvent : GameEvent
{
    public bool canFollowWaterLevel = false;

    public FollowWaterLevelEvent(bool canFollowWaterLevel)
    {
        this.canFollowWaterLevel = canFollowWaterLevel;
    }
}

public class DoorOpenEvent : GameEvent
{
    public bool isDoorOpen = false;
    public DoorOpenEvent(bool isDoorOpen)
    {
        this.isDoorOpen = isDoorOpen;
    }
}

public class GeneratorMalfunctionEvent : GameEvent
{

}

public class DoorBlockEvent : GameEvent
{

}