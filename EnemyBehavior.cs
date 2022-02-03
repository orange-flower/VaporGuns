using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float speedProp;
    private float speed;

    private Vector2 startLoc;

    public GameObject enemyBullet;

    private bool isTicking = false;

    void Start()
    {
        speedProp = 75;
        speed = speedProp / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTicking)
        {
            StartCoroutine(TimerCoroutine());
        }
        transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
    }

    //this function checks if the player or player bullet enters the enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player, destroy the enemy
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        //if player bullet, destroy enemy and bullet and update score
        if (collision.gameObject.tag == "PlayerBullet")
        {
            GameManager.current.sfx.PlayOneShot(GameManager.current.clipArray[0], 1);
            Tracker.currentScore += 10;
            //Debug.Log("enemies killed" + " " + Tracker.currentScore);
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    //this function shoots enemy bullets 
    private void enemyShooting()
    {
        {
            startLoc = this.gameObject.transform.position;
            GameObject projectile = Instantiate(enemyBullet, startLoc + new Vector2(0, -1), Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5);
        }
    }

    //the coroutine sets the pace of the enemy shooting
    IEnumerator TimerCoroutine()
    {
        isTicking = true;
        yield return new WaitForSeconds(1.0f);
        enemyShooting();
        isTicking = false;
    }
}
