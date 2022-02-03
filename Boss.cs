using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject bossPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function that instantiates boss
    public void SpawnBoss(int hp, int miniHP)
    {
        //spawn boss from prefab, set main boss hp
        //Debug.Log("spawned boss");
        GameObject boss = Instantiate(bossPrefab, new Vector3(0f, 9.5f, 1), Quaternion.identity);
        boss.GetComponent<BossHP>().SetBossHP(hp);

        //go through each mini boss and set hp
        for (int i = 0; i < boss.transform.GetChild(1).transform.childCount; i++)
        {
            boss.transform.GetChild(1).transform.GetChild(i).GetComponent<MiniBossHP>().SetMiniBossHP(miniHP);
        }
        //Debug.Log("spawned hp: " + hp);
    }
}
