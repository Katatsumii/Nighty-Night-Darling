using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLevel1: MonoBehaviour
{
    [SerializeField]
    GameObject[] monsterReference;
    GameObject spawnedMonster;
    [SerializeField]
    private Transform spawner1, spawner2,spawner3;
    private int randomSpawner, randomMonster;
    public int spawnRange;


    public float spawnCount;
    private void Update()
    {
        if (spawnCount == 10 || spawnCount == 20 || spawnCount==30)
        {
        StartCoroutine(Spawner());
        }
    }
    IEnumerator Spawner()
    {
        while (spawnCount>=1)
        {
            spawnCount--;
            yield return new WaitForSeconds(Random.Range(1,spawnRange));
            randomMonster = Random.Range(0, monsterReference.Length);
            randomSpawner = Random.Range(0, 3);
            spawnedMonster = Instantiate(monsterReference[randomMonster]);
            if (randomSpawner == 0)
            {
                spawnedMonster.transform.position = spawner1.position;
            }
            else if (randomSpawner == 1)
            {
                spawnedMonster.transform.position = spawner2.position;
            }
            else if (randomSpawner == 2)
            {
                spawnedMonster.transform.position= spawner3.position;
            }
           

        }
    }
}
