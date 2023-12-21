using UnityEngine;

public abstract class AudioManager
{

    public abstract void OnStart();
    public abstract void OnUpdate();
}

public class Level2AudioManager : AudioManager
{
    public override void OnStart()
    {

    }

    public override void OnUpdate()
    {

    }

    public static void OnLeverPull()
    {
        SpawnObjectAddressables.GetLevelDatathroughID("Generator").GetComponentInChildren<AudioSource>().Play();
        GameObject waterPipe = SpawnObjectAddressables.GetLevelDatathroughID("WaterPipe");
        AudioSource[] audioSources = waterPipe.GetComponentsInChildren<AudioSource>();
        audioSources[0].Stop();
        audioSources[1].PlayDelayed(3f);
    }

}
