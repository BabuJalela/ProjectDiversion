using System.Collections;
using UnityEngine;

public class CamHandler : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CamActiveRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CamActiveRoutine()
    {
        yield return new WaitForSeconds(5f);
        this.gameObject.SetActive(false);
    }
}
