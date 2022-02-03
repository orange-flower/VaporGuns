using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootyMcShootFace : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab1;
    public GameObject bulletPrefab2;

    public GameObject player1;
    public GameObject player2;

    private Vector2 startLoc1;
    private Vector2 startLoc2;

    public KeyCode p1ShootKey;
    public KeyCode p2ShootKey;

    private bool isTicking1 = false;
    private bool isTicking2 = false;
    private bool player1CanShoot = true;
    private bool player2CanShoot = true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTicking1)
        {
            StartCoroutine(Player1Coroutine());
        }
        if (!isTicking2)
        {
            StartCoroutine(Player2Coroutine());
        }
        playerShooting();
    }
    private void playerShooting()
    {
        if (Input.GetKey(p1ShootKey))
        {
            if (player1CanShoot)
            {
                startLoc1 = player1.transform.position;
                GameManager.current.sfx.PlayOneShot(GameManager.current.clipArray[2], 0.6f);
                GameObject projectile = Instantiate(bulletPrefab1, startLoc1 + new Vector2(0, 1), Quaternion.identity);
                projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 15);
                player1CanShoot = false;
            }
        }

        if (!Tracker.track.isSingleMode)
        {
            if (Input.GetKey(p2ShootKey))
            {
                if (player2CanShoot)
                {
                    startLoc2 = player2.transform.position;
                    GameManager.current.sfx.PlayOneShot(GameManager.current.clipArray[2], 0.6f);
                    GameObject projectile = Instantiate(bulletPrefab2, startLoc2 + new Vector2(0, 1), Quaternion.identity);
                    projectile.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 15);
                    player2CanShoot = false;
                }
            }
        }
            
    }

    IEnumerator Player1Coroutine()
    {
        isTicking1 = true;
        yield return new WaitForSeconds(0.3f);
        player1CanShoot = true;
        isTicking1 = false;
    }
    IEnumerator Player2Coroutine()
    {
        isTicking2 = true;
        yield return new WaitForSeconds(0.3f);
        player2CanShoot = true;
        isTicking2 = false;
    }
}