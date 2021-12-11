using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        //if the explosion hits the enemies, destroy them
        //if the explosion hits the boss, deduct hp
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
        
        else if (other.tag == "Boss")
        {
            BossHP hpScript = other.GetComponent<BossHP>();
            MiniBossHP miniHpScript = other.GetComponent<MiniBossHP>();
            hpScript.bossHealth -= 50;
            miniHpScript.miniBossHealth -= 50;
        }
    }
}
