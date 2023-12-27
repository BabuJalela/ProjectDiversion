using Events;
using UnityEngine;

public class FollowWaterLevel : MonoBehaviour
{
    private bool isWaterFilling = false;
    private void OnEnable()
    {
        GameEventManager.Instance.AddListener<FollowWaterLevelEvent>(WaterRippleFollowWaterLevel);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isWaterFilling)
        {
            transform.position = new Vector3(transform.position.x, SpawnObjectAddressables.GetLevelDatathroughID("Water").transform.position.y + 0.01f, transform.position.z);
        }
    }

    private void WaterRippleFollowWaterLevel(FollowWaterLevelEvent e)
    {
        isWaterFilling = e.canFollowWaterLevel;
    }

    private void OnDisable()
    {
        GameEventManager.Instance.RemoveListener<FollowWaterLevelEvent>(WaterRippleFollowWaterLevel);
    }
}
