using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerLevel2 : MonoBehaviour
{
    [SerializeField]
    GameObject[] monsterReference;
    GameObject spawnedMonster;
    [SerializeField]
    private Transform spawner1, spawner2;
    private int randomSpawner, randomMonster;

    public int spawnRange;


    public float spawnCount;
    private void Update()
    {
        if(spawnCount==25||spawnCount==40||spawnCount==55)
        {
            StartCoroutine(Spawner());
        }
    }
    IEnumerator Spawner()
    {
        while (spawnCount>=1)
        {
            spawnCount--;
            yield return new WaitForSeconds(Random.Range(1, spawnRange));
            randomMonster = Random.Range(0, monsterReference.Length);
            randomSpawner = Random.Range(0, 2);
            spawnedMonster = Instantiate(monsterReference[randomMonster]);
            if (randomSpawner == 0)
            {
                spawnedMonster.transform.position = spawner1.position;
            }
            else if (randomSpawner == 1)
            {
                spawnedMonster.transform.position = spawner2.position;
            }
           
        }
    }
}
