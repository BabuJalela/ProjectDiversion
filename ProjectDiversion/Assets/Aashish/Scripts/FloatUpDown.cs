using UnityEngine;

public class FloatUpDown : MonoBehaviour
{
    public float floatSpeed = 1.0f; 
    public float floatHeight = 1.0f;
    public Vector3 initialPosition;

    private void Start()
    {
        transform.position = initialPosition;
    }

    private void Update()
    {
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
