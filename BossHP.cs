using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    //bos properties
    public int bossHealth;
    public Slider hpSliderMain;
    public bool stageOver;
    public GameObject bossPrefab;
    public int miniBossesLeft;

    // Start is called before the first frame update
    void Start()
    {
        //setup new boss
        miniBossesLeft = 6;
        stageOver = false;
        hpSliderMain.gameObject.SetActive(false);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //update to consistently check for when to update main boss body and keep hp up to date
        ActivateBigBoss();
        UpdateBossHP();
    }

    //if the collision is a player bullet, deduct 2 damage, and destroy bullet
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet")
        {
            bossHealth -= 2;
            Destroy(other.gameObject);
        }    
    }

    //this function sets the hp var and slider max val to the specified hp
    public void SetBossHP(int hp)
    {
        //Debug.Log("Boss for Stage " + GameManager.current.stageNum);
        bossHealth = hp;
        //Debug.Log("Boss " + GameManager.current.stageNum + " hp: " + bossHealth);
        hpSliderMain.maxValue = hp;
        //Debug.Log("Boss " + GameManager.current.stageNum + " slider val: " + hpSlider.maxValue);
    }

    //this function updates boss's hp slider
    //when boss is at 0 hp, destroy boss gameObject, and call a new stage and update score
    private void UpdateBossHP()
    {
        hpSliderMain.value = bossHealth;
        if (bossHealth <= 0)
        {
            stageOver = true;
            GameManager.current.Stage();
            Tracker.currentScore += 50;
            Destroy(gameObject);
        }
    }

    //this function is only called when all mini bosses are dead
    //it makes the big boss damagable
    private void ActivateBigBoss()
    {
        if (miniBossesLeft <= 0)
        {
            hpSliderMain.gameObject.SetActive(true);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}
