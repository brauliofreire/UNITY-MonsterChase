using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monstersReferences;

    [SerializeField]
    private GameObject spawnedMonster;

    [SerializeField]
    private Transform leftPos, rightPos;

    private int randomIndex, randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    IEnumerator SpawnMonsters()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            
            randomIndex = Random.Range(0, monstersReferences.Length);
            randomSide = Random.Range(0, 2);
            spawnedMonster = Instantiate(monstersReferences[randomIndex]);

            if(randomSide == 0)//left side
            {
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monsters>().speed = Random.Range(4, 10);
            }
            else//right side
            {
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monsters>().speed = -Random.Range(4, 10);
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
            }
        }
    }
}
