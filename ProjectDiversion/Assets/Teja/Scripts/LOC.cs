using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LOC : MonoBehaviour
{
    public GameObject enemyPrefabs;
    [SerializeField] private string playertag = "Player";
    public GameObject GoodpatrolEnemy;

    private void Start()
    {
        enemyPrefabs.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(playertag))
        {
            SpawnEnemies();
            Debug.Log("xoxo");
        }
    }

    private void SpawnEnemies()
    {
        enemyPrefabs.SetActive(true);
        Destroy(GoodpatrolEnemy, 1f);
        Destroy(gameObject, 2f);
    }
}
