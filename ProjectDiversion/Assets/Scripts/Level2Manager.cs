using Events;
using UnityEngine;

public class Level2Manager : BaseLevelManager
{
    private bool isGeneratorActive = true;
    public bool isDoorBlocked = false;
    public override void OnInitialize()
    {

    }

    public override void OnRegisterListener()
    {
        GameEventManager.Instance.AddListener<LeverPullEvent>(OnLeverActivate);
        GameEventManager.Instance.AddListener<DoorBlockEvent>(OnDoorBlock);
    }

    public override void OnUnregisterListener()
    {
        GameEventManager.Instance.RemoveListener<LeverPullEvent>(OnLeverActivate);
        GameEventManager.Instance.RemoveListener<DoorBlockEvent>(OnDoorBlock);
    }

    public override void OnUpdate()
    {
        GeneratorMalfunction();
    }

    private void OnLeverActivate(LeverPullEvent e)
    {
        OnLeverPull(e.canFill);
    }

    private void OnDoorBlock(DoorBlockEvent e)
    {
        isDoorBlocked = true;
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
            var Outdoor = SpawnObjectAddressables.GetLevelDatathroughID("Outdoor");
            Outdoor.transform.position = new Vector3(Outdoor.transform.position.x, Outdoor.transform.position.y + 5f, Outdoor.transform.position.z);
            SpawnObjectAddressables.GetLevelDatathroughID("Light").SetActive(true);
        }
        else
        {
            waterFallPS.Stop();
            waterFallPS2.Stop();
            GameEventManager.Instance.TriggerEvent(new FollowWaterLevelEvent(false));
            SpawnObjectAddressables.GetLevelDatathroughID("Generator").GetComponentInChildren<Light>().intensity = 0;
            SpawnObjectAddressables.GetLevelDatathroughID("Light").SetActive(false);
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


}
