using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour
{
    public GameObject shieldPU;
    public GameObject bombPU;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiatePU()
    {
        StartCoroutine(SpawnPU());
    }

    //this function spawns the powerup
    IEnumerator SpawnPU()
    {
        int percentile = Random.Range(1, 11); //random int to decide which powerup to use
        float posX = Random.Range(-2.5f, 2.5f); //random int x position
        float interval = Random.Range(10, 60); //spawn power up between 10-60 seconds 
        //Debug.Log("PU Interval: " + interval);
        //Debug.Log("PU Percentile: " + percentile);

        yield return new WaitForSeconds(interval);
        if (percentile > 7) //30% chance of shield
        {
            //spawn shield
            //Debug.Log("shield spawned");
            GameObject shield = Instantiate(shieldPU, new Vector3(posX, 6, 0), Quaternion.identity);
        }
        else if (percentile <= 7) //70% chance of bomb
        {
            //spawn bomb
            //Debug.Log("bomb spawned");
            GameObject shield = Instantiate(bombPU, new Vector3(posX, 6, 0), Quaternion.identity);
        }
    }
}
