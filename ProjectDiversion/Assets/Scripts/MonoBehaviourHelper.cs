using UnityEngine;

public class MonoBehaviourHelper : MonoBehaviour
{
    public static MonoBehaviourHelper instance;
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
