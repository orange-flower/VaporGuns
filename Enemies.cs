using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Boss bossScript;
    public GameObject[] enemyPrefabs;
    public Sprite[] enemyImg; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //pass in variables to call the coroutine
    public void SpawnEnemyWave(int wave, int seconds, int bossHP, int miniBossHP)
    { 
        StartCoroutine(SpawnDelay(wave, seconds, bossHP, miniBossHP));
    }

    //this function instantiates the enemies and boss
    IEnumerator SpawnDelay(int num, int interval, int hp, int miniHp)
    {
        //Debug.Log("spawn wave: " + num);
        if (num > 0)
        {
            //instantiate a random wave pattern
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            GameObject enemyWave = Instantiate(enemyPrefab, new Vector3(-1f, 0f, 1), Quaternion.identity);

            //randomly assign the sprite of each enemy in wave to either left or right hand sprite
            for (int i = 0; i < enemyWave.transform.childCount; i++)
            {
                enemyWave.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = enemyImg[Random.Range(0, enemyImg.Length)];
            }

            yield return new WaitForSeconds(interval);

            //recursive call to spawn as many waves as needed
            StartCoroutine(SpawnDelay(num - 1, interval, hp, miniHp));
        }
        else if (num == 0)
        {
            //if wave is 0, spawn boss
            //Debug.Log("Mini Boss hp: " + miniHp);
            bossScript.SpawnBoss(hp, miniHp);
        }
    }
}
