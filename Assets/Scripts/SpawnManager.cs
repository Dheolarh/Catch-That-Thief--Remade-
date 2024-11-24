using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> enemyPrefabs;
    private int _timing;
    void Start()
    {
        _timing = Random.Range(1, 5);
        StartCoroutine("spawnEnemies");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int RandomSpawning()
    {
        int spawnRange = Random.Range(0, enemyPrefabs.Count);
        return spawnRange;
    }

    Vector3 SpawnPosition()
    {
        Vector3 spawnPos = new Vector3(951, 540, -3);
        return spawnPos;
    }

    IEnumerator spawnEnemies()
    {
        float spawnDimension = 960f;
        Instantiate(enemyPrefabs[RandomSpawning()], SpawnPosition(), enemyPrefabs[RandomSpawning()].transform.rotation);
        if (enemyPrefabs[RandomSpawning()].transform.position.x > spawnDimension)
        {
            Destroy(enemyPrefabs[RandomSpawning()]);
        }
        yield return new WaitForSeconds(_timing);
    }
}
