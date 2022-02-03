using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public Powerups powerScript;

    public int health;

    public Animator iFrameAnim;
    public int invinSeconds;

    public SpriteRenderer playerSprite;
    public Sprite pl1;
    public Sprite pl2;
    public Sprite pl3;

    private bool isInvinc;

    void Start()
    {
        //set up health
        health = 3;
        invinSeconds = 3;
        isInvinc = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //this function is attached to each player car and checks what collides with it 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if shield isnt on or youre not invincible, take damage 
        if ((powerScript.shieldOn == false) && (isInvinc == false))
        {
            //Debug.Log("Invincible? " + isInvinc);
            if (collision.gameObject.tag == "Enemy")
            {
                isInvinc = true;
                //Debug.Log("Took dmg " + isInvinc);
                iFrameAnim.SetBool("gotHit", true);
                health -= 1;
                healthChecks();
            }
            if (collision.gameObject.tag == "EnemyBullet")
            {
                isInvinc = true;
                //Debug.Log("Took dmg " + isInvinc);
                iFrameAnim.SetBool("gotHit", true);
                health -= 1;
                healthChecks();
                Destroy(collision);
            }
            if (collision.gameObject.tag == "Boss")
            {
                isInvinc = true;
                //Debug.Log("Took dmg " + isInvinc);
                iFrameAnim.SetBool("gotHit", true);
                health -= 1;
                healthChecks();
            }
        }
    }

    //this function runs each time you take damage
    private void healthChecks()
    {
        //start iinvincibility frames each time you take damage
        //Debug.Log("Invincibility begins, HP: " + health);
        StartCoroutine(InvincibilityFrames(invinSeconds));

        //swap sprite each time you take damage
        GameManager.current.sfx.PlayOneShot(GameManager.current.clipArray[4], 1);
        if (health == 3)
        {
            playerSprite.sprite = pl3;
        }
        if (health == 2)
        {
            playerSprite.sprite = pl2;
        }
        if (health == 1)
        {
            playerSprite.sprite = pl1;
        }
        if (health <= 0)
        {
            if (this.gameObject.tag == "Player")
            {
                //if 0 lives, destroy player car
                GameManager.current.sfx.PlayOneShot(GameManager.current.clipArray[3], 1);
                Destroy(gameObject);
                GameManager.current.numPlayers -= 1;

                //check if both players are dead, load end scene if so
                if (GameManager.current.numPlayers == 0)
                {
                    SceneManager.LoadScene("EndScene");
                    //GameManager.current.gameOver = true;
                }
            }
        }

        //this function makes you invincible for 3 seconds
        //it recursive calls to deduct a second
        IEnumerator InvincibilityFrames(int seconds)
        {
            //if seconds are more than 0, deduct second, call this func again
            //Debug.Log("Invincible for " + seconds + "    HP: " + health);
            if (seconds > 0)
            {
                yield return new WaitForSeconds(1);
                StartCoroutine(InvincibilityFrames(seconds -= 1));
            }
            //if seconds is 0 or less, youre no longer invinc, stop animation 
            else if (seconds <= 0)
            {
                isInvinc = false;
                iFrameAnim.SetBool("gotHit", false);
            }
        }
    }

    

}
