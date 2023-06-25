using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterRefrence;
    private GameObject spawnedMonster;
    [SerializeField]
    private Transform leftPos, rightPos;
    private int randomIndex;
    private int randomSide;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    IEnumerator SpawnEnemies(){
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1,5));
            randomIndex = Random.Range(0,monsterRefrence.Length);
            randomSide = Random.Range(0,2);
            spawnedMonster = Instantiate(monsterRefrence[randomIndex]);
            if(randomSide==0){
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Enemy>().speed = -Random.Range(4,10);
                spawnedMonster.transform.localScale = new Vector3(-1f , 1f , 1f);
            }else{
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Enemy>().speed = Random.Range(4,10);
            }
        }
    }
}
