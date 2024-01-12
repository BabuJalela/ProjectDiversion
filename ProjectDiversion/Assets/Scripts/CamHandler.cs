using System.Collections;
using UnityEngine;

public class CamHandler : MonoBehaviour
{
    private Movements movements;
    // Start is called before the first frame update
    void Start()
    {
        movements = SpawnObjectAddressables.GetLevelDatathroughID(level2SpawnedObjectIDs.PLAYER)?.GetComponent<Movements>();
        StartCoroutine(CamActiveRoutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CamActiveRoutine()
    {
        yield return new WaitForSeconds(5f);
        movements.stopPlayerMove = false;
        this.gameObject.SetActive(false);
    }
}
