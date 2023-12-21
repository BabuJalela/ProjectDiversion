using Events;
using UnityEngine;

public abstract class LevelManager
{
    public abstract void OnStart();
    public abstract void OnUpdate();

}

public class Level2Manager : LevelManager
{
    public override void OnStart()
    {
        SpawnObjectAddressables.GetLevelDatathroughID("Generator").GetComponentInChildren<Light>().intensity = 5;
    }

    public override void OnUpdate()
    {

    }

    public static string OnLeverPull()
    {
        SpawnObjectAddressables.GetLevelDatathroughID("WaterPipe").GetComponentInChildren<ParticleSystem>().Play();
        GameEventManager.Instance.TriggerEvent(new FollowWaterLevelEvent());
        SpawnObjectAddressables.GetLevelDatathroughID("Generator").GetComponentInChildren<Light>().intensity = 1;
        return nameof(OnLeverPull);
    }
}
