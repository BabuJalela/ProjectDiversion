using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashSceneHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneLoadRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SceneLoadRoutine()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
