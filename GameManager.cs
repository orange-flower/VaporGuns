using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager current;

    //script references
    public Enemies enemiesScript;
    public SpawnPowerUps spawnPUScript;
    public Boss bossScript;

    //game enemy wave variables
    public int numWave;
    public int spawnDelay;

    //game boss variables
    public int bossHealth;
    public int miniBossHealth;

    public int stageNum;
    public int numPlayers;

    public GameObject player1Car;
    public GameObject player2Car;

    public Toggle p2Toggle;

    // score stuff
    public Text scoreText;

    //audio variables
    public AudioSource sfx;
    public AudioClip[] clipArray;

    // Start is called before the first frame update
    void Start()
    {
        current = this;

        //set up
        numWave = 2;
        spawnDelay = 7;
        stageNum = 0;
        bossHealth = 30;
        miniBossHealth = 20;
        sfx = GetComponent<AudioSource>();
        Tracker.currentScore = 0;

        if (Tracker.track.isSingleMode)
        {
            //SINGLE PLAYER
            //only show player 1 car and center the vehicle in the screen
            player1Car.SetActive(true);
            player2Car.SetActive(false);
            player1Car.GetComponent<Transform>().transform.position = new Vector2(0, -4);
            p2Toggle.gameObject.SetActive(false);
            numPlayers = 1; 
            Debug.Log("Single Player");
        }
        else
        {
            //MULTIPLAYER
            //show both players & increase boss's starting hp
            player1Car.SetActive(true);
            player2Car.SetActive(true);
            bossHealth += 15;
            miniBossHealth += 10;
            numPlayers = 2;
            Debug.Log("Multiplayer");
        }

        Stage();
    }

    // Update is called once per frame
    void Update()
    {
        //update score
        scoreText.text = Tracker.currentScore.ToString();
    }

    //stage function spawns one stage which consists of waves of enemies and then the boss
    //after everything is spawned, game vars are incremented for next stage 
    public void Stage()
    {
        stageNum += 1;
        Debug.Log("stage " + stageNum + " started");

        enemiesScript.SpawnEnemyWave(numWave, spawnDelay, bossHealth, miniBossHealth);

        //two power ups per stage
        spawnPUScript.InstantiatePU();
        spawnPUScript.InstantiatePU();

        spawnDelay -= 1;

        if (PlayerPrefs.GetString("PlayerMode") == "Multi")
        {
            //increase hp incrementation for multiplayer
            bossHealth += 10;
            miniBossHealth += 5;
        }

        //if even number stage, add another wave aka every other stage increases by one wave
        if (stageNum % 2 == 0) 
        {
            numWave += 1;
        }

        //cap boss hp at 200
        if (bossHealth < 200) 
        {
            bossHealth += 15;
            miniBossHealth += 10;
        }

        //minimum 2 second delay 
        if (spawnDelay < 2)
        {
            spawnDelay = 2;
        }
    }
}
