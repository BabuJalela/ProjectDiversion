using Events;
using UnityEngine;

public class Level2AudioManager : BaseAudioManager
{
    public override void OnInitialize()
    {

    }


    public override void OnRegisterListener()
    {
        GameEventManager.Instance.AddListener<LeverPullEvent>(LeverPull);
    }

    public override void OnUnregisterListener()
    {
        GameEventManager.Instance.RemoveListener<LeverPullEvent>(LeverPull);
    }

    public override void OnUpdate()
    {

    }

    private void LeverPull(LeverPullEvent e)
    {
        OnLeverPull(e.canFill);
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
