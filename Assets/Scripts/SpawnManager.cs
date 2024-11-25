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
        _timing = Random.Range(2, 5);
        StartCoroutine("spawnEnemies");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int RandomSpawning()
    {
        return Random.Range(0, enemyPrefabs.Count);;
    }

    Vector3 SpawnPosition()
    {
        return new Vector3(-11, 0.3f, -3);;
    }

    IEnumerator spawnEnemies()
    {
        while (true)
        {
            int randomIndex = RandomSpawning();
            GameObject enemy = Instantiate(enemyPrefabs[randomIndex], SpawnPosition(), enemyPrefabs[randomIndex].transform.rotation);
            if (enemyPrefabs[RandomSpawning()].transform.position.x > 0)
            {
                Destroy(enemy);
            }
            yield return new WaitForSeconds(_timing);
        }

    }
}
