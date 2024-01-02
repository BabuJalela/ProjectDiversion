using Events;
using UnityEngine;

public class Level2Manager
{
    private bool isGeneratorActive = true;
    public bool isDoorBlocked = false;
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
        ParticleSystem waterFallPS2 = SpawnObjectAddressables.GetLevelDatathroughID("WaterPipe2").GetComponentInChildren<ParticleSystem>();
        if (isGeneratorActive)
        {
            waterFallPS.Play();
            waterFallPS2.Play();
            GameEventManager.Instance.TriggerEvent(new FollowWaterLevelEvent(true));
            SpawnObjectAddressables.GetLevelDatathroughID("Generator").GetComponentInChildren<Light>().intensity = 1;
        }
        else
        {
            waterFallPS.Stop();
            waterFallPS2.Stop();
            GameEventManager.Instance.TriggerEvent(new FollowWaterLevelEvent(false));
            SpawnObjectAddressables.GetLevelDatathroughID("Generator").GetComponentInChildren<Light>().intensity = 0;
        }
    }

    private void GeneratorMalfunction()
    {
        if (SpawnObjectAddressables.GetLevelDatathroughID("Water").transform.position.y > SpawnObjectAddressables.GetLevelDatathroughID("Generator").transform.position.y && isGeneratorActive && !isDoorBlocked)
        {
            GameEventManager.Instance.TriggerEvent(new LeverPullEvent(false));
            isGeneratorActive = false;
        }
    }

    private void ReduceCuboardWeightToMove()
    {
        StoredObjects storedObjects = SpawnObjectAddressables.GetLevelDatathroughID("Cuboard").GetComponentInChildren<StoredObjects>();
        if (storedObjects != null)
        {

        }
    }

}
