using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniBossHP : MonoBehaviour
{
    public BossHP bossScript;
    public int miniBossHealth;
    public Slider miniHpSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMiniBossHP();
    }

    //check if player bullet entered and deduct 2 points from mini boss and destroy bullet
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerBullet")
        {
            miniBossHealth -= 2;
            Destroy(other.gameObject);
        }
    }

    //set mini boss hp var and slider max 
    public void SetMiniBossHP(int hp)
    {
        miniBossHealth = hp;
        miniHpSlider.maxValue = hp;
    }

    //change mini boss hp
    public void UpdateMiniBossHP()
    {
        //update slider
        miniHpSlider.value = miniBossHealth;
        //if the hp is less than 0, deduct from total miniboss, deactivate slider, and destroy game obj
        if (miniBossHealth <= 0)
        {
            bossScript.miniBossesLeft -= 1;
            miniHpSlider.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
