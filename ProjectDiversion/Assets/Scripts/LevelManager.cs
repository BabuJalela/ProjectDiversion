using Events;
using UnityEngine;

public class Level2Manager
{
    private bool isGeneratorActive = true;
    public void OnStart()
    {

    }

    public void OnUpdate()
    {
        GeneratorMalfunction();
    }

    public void OnLeverPull(bool isGeneratorActive)
    {
        ParticleSystem waterFallPS = SpawnObjectAddressables.GetLevelDatathroughID("WaterPipe").GetComponentInChildren<ParticleSystem>();
        if (isGeneratorActive)
        {
            waterFallPS.Play();
            GameEventManager.Instance.TriggerEvent(new FollowWaterLevelEvent(true));
            SpawnObjectAddressables.GetLevelDatathroughID("Generator").GetComponentInChildren<Light>().intensity = 1;
        }
        else
        {
            waterFallPS.Stop();
            GameEventManager.Instance.TriggerEvent(new FollowWaterLevelEvent(false));
            SpawnObjectAddressables.GetLevelDatathroughID("Generator").GetComponentInChildren<Light>().intensity = 0;
        }
    }

    private void GeneratorMalfunction()
    {
        if (SpawnObjectAddressables.GetLevelDatathroughID("Water").transform.position.y > SpawnObjectAddressables.GetLevelDatathroughID("Generator").transform.position.y && isGeneratorActive)
        {
            GameEventManager.Instance.TriggerEvent(new LeverPullEvent(false));
            isGeneratorActive = false;
        }
    }
}
