using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Powerups : MonoBehaviour
{
    //vars for powerup control
    public bool shieldOn;
    private string currPower;
    [SerializeField] private KeyCode powerKey;
    [SerializeField] private GameObject bombArea;
    [SerializeField] private GameObject shieldSprite;

    //UI var
    [SerializeField] private Toggle powerHolder;
    [SerializeField] private Sprite bombIcon;
    [SerializeField] private Sprite shieldIcon;
    [SerializeField] private GameObject checkmark;
    [SerializeField] private string playerName;
    [SerializeField] private Text puAcquireText;

    //animator
    [SerializeField] private Animator textAnimator;

    // Start is called before the first frame update
    void Start()
    {
        //initialize 
        currPower = "";
        shieldOn = false;
        powerHolder.enabled = false;
        shieldSprite.SetActive(false);
        //puAcquireText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if player uses powerup button, use the powerup
        if (Input.GetKeyDown(powerKey))
        {
            //Debug.Log("Curr Powerup: " + currPower);
            if (currPower != "")
            {
                UsePowerUp();
                powerHolder.isOn = false;
            }
        }
    }

    //check which powerup was picked up
    public void OnTriggerEnter2D(Collider2D other)
    {
        //inform player what powerup was picked up and update the toggle art
        //destroy powerup obj
        if (other.tag == "Shield")
        {
            StartCoroutine(ShowText("Shield"));
            checkmark.GetComponent<Image>().sprite = shieldIcon;
            powerHolder.isOn = true;
            currPower = "shield";
            Destroy(other.gameObject);
        }
        else if (other.tag == "Bomb")
        {
            StartCoroutine(ShowText("Bomb"));
            checkmark.GetComponent<Image>().sprite = bombIcon;
            powerHolder.isOn = true;
            currPower = "bomb";
            Destroy(other.gameObject);
        }
    }

    //this function uses the specified powerup
    public void UsePowerUp()
    {
        if (currPower == "shield")
        {
            GameManager.current.sfx.PlayOneShot(GameManager.current.clipArray[5], 1);
            StartCoroutine(UseShield());
            currPower = "";
        }
        else if (currPower == "bomb")
        {
            StartCoroutine(DeployBomb());
            currPower = "";
        }
    }

    //this function turns on shield for 5 seconds
    IEnumerator UseShield()
    {
        shieldOn = true;
        shieldSprite.SetActive(true);
        yield return new WaitForSeconds(5);
        shieldSprite.SetActive(false);
        shieldOn = false;
    }

    //this function spawn the bomb and destroy 1 second later
    IEnumerator DeployBomb()
    {
        Transform playerPos = GetComponent<Transform>();
        GameManager.current.sfx.PlayOneShot(GameManager.current.clipArray[1], 1);
        Vector2 newPos = new Vector2(playerPos.position.x, playerPos.position.y + 2.5f);
        GameObject area = Instantiate(bombArea, newPos, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Destroy(area);
    }

    //pops up text to inform player what powerup was acquired
    IEnumerator ShowText(string power)
    {
        //puAcquireText.gameObject.SetActive(true);
        puAcquireText.text = playerName + " Acquired \n\n" + power;
        textAnimator.SetBool("textAppear", true);
        yield return new WaitForSeconds(2);
        textAnimator.SetBool("textAppear", false);
        //puAcquireText.gameObject.SetActive(false);

    }
}
