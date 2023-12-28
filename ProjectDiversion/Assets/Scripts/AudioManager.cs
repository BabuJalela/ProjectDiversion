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

    public void OnLeverPull(bool isGeneratorActive)
    {
        AudioSource generatorAudioSource = SpawnObjectAddressables.GetLevelDatathroughID("Generator").GetComponentInChildren<AudioSource>();
        GameObject waterPipe = SpawnObjectAddressables.GetLevelDatathroughID("WaterPipe");
        GameObject waterPipe2 = SpawnObjectAddressables.GetLevelDatathroughID("WaterPipe2");
        AudioSource[] audioSources = waterPipe.GetComponentsInChildren<AudioSource>();
        AudioSource[] audioSources2 = waterPipe2.GetComponentsInChildren<AudioSource>();
        if (isGeneratorActive)
        {
            generatorAudioSource.Play();
            audioSources[0].Stop();
            audioSources[1].PlayDelayed(3f);
            audioSources2[0].Stop();
            audioSources2[1].PlayDelayed(3f);
        }
        else
        {
            generatorAudioSource.Stop();
            audioSources[1].Stop();
            audioSources2[1].Stop();
        }
    }

}
