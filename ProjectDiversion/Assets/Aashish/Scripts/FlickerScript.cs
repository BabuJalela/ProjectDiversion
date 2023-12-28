using UnityEngine;

public class FlickerScript : MonoBehaviour
{
    private Light spotlight;
    private bool isFlickering = false;
    private int flickerCount = 0;

    void Start()
    {
        spotlight = GetComponent<Light>();
        InvokeRepeating("StartFlicker", 0f, 3f);
    }

    void Update()
    {
        if (isFlickering)
        {
            Flicker();
        }
    }

    void StartFlicker()
    {
        isFlickering = true;
        flickerCount = 0;
    }

    void Flicker()
    {
        if (flickerCount < 3)
        {
            spotlight.enabled = !spotlight.enabled;
            flickerCount++;
        }
        else
        {
            flickerCount = 0;
            isFlickering = false;

            spotlight.enabled = true;
        }
    }
}
