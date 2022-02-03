using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    //shooting pattern prefabs
    public GameObject shootPattern1;
    public GameObject shootPattern2;

    //boss parts
    public List<GameObject> bossParts;

    //boss part locations
    private Vector2 startLoc;

    //couroutine setup
    private bool isTicking = false;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isTicking)
        {
            StartCoroutine(TimerCoroutine());
        }
    }

    private void BossShooting()
    {
        if (bossParts[counter] == null)
        {
            bossParts.RemoveAt(counter);
        }

        startLoc = bossParts[counter].gameObject.transform.position;
        //startLoc = this.transform.GetChild(1).transform.GetChild(counter).GetComponent<Rigidbody2D>().transform.position;

        if (counter % 2 == 0)
        {
            GameObject projectile = Instantiate(shootPattern1, startLoc + new Vector2(0, -1), Quaternion.identity);
            for(int x = 0; x < projectile.transform.childCount; x++)
            {
                projectile.transform.GetChild(x).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
                //this.transform.GetChild(1).transform.GetChild(x).GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
            }   
        }
        else
        {
            GameObject projectile = Instantiate(shootPattern2, startLoc + new Vector2(0, -1), Quaternion.identity);
            for (int x = 0; x < projectile.transform.childCount; x++)
            {
                projectile.transform.GetChild(x).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
                //this.transform.GetChild(1).transform.GetChild(x).GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
            }
        }

        //reset through counter system
        counter += 1;
        if (counter >= bossParts.Count)
        {
            counter = 0;
        }
    }

    IEnumerator TimerCoroutine()
    {
        isTicking = true;
        yield return new WaitForSeconds(1.0f);
        BossShooting();
        isTicking = false;
    }
}
