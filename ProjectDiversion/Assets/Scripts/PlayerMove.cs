using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float verticalAxis = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 2;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 2;
        }
        transform.Translate(new Vector3(horizontalAxis, 0, verticalAxis));

    }
}
