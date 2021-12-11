using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    //shooting pattern prefabs
    public GameObject[] shootPattern;

    //boss parts
    public List<GameObject> bossParts;

    //boss part locations
    private Vector2 startLoc;

    //couroutine setup
    private bool isTicking = false;
    private int counter = 0;
    public bool patter = true;

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
        Debug.Log("Shooting");
        //checks if shooting part is destroyed
        if (bossParts[counter] == null)
        {
            bossParts.RemoveAt(counter);
        }
        //gets the start location of the boss part
        startLoc = bossParts[counter].gameObject.transform.position;
        //startLoc = this.transform.GetChild(1).transform.GetChild(counter).GetComponent<Rigidbody2D>().transform.position;

        // instatiate prefab
        GameObject projectile = Instantiate(shootPattern[Random.Range(0,2)], startLoc + new Vector2(0, -1), Quaternion.identity);
        for (int x = 0; x < projectile.transform.childCount; x++)
        {
            //add velocity to prefab
            projectile.transform.GetChild(x).gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
            //this.transform.GetChild(1).transform.GetChild(x).GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
        }
        patter = true;
        
        //reset through counter system
        counter += 1;
        if (counter >= bossParts.Count)
        {
            counter = 0;
        }
    }

    IEnumerator TimerCoroutine()
    {
        //times boss shooting
        isTicking = true;
        yield return new WaitForSeconds(1.0f);
        BossShooting();
        patter = !patter;
        isTicking = false;
    }
}
