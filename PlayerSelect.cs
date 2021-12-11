using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerSelect : MonoBehaviour
{
    public static PlayerSelect selection;

    //player select vars
    private float currTime;
    private int pressCount;
    private bool p1Play;
    private bool p2Play;

    //UI vars
    public Toggle player1Tog;
    public Toggle player2Tog;
    public Text timerText;
    public Text p1Instructions;
    public Text p2Instructions;
    public Text modeText;

    //controls
    public KeyCode p1Start;
    public KeyCode p2Start;

    //transition var
    public Animator transition;
    public float transitionTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //setup player select
        Tracker.track.isSingleMode = true;
        player1Tog.isOn = false;
        player2Tog.isOn = false;
        currTime = 10;
        pressCount = 0;
        modeText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        timerText.text = "10";
        p1Instructions.text = "Press Start to Join";
        p2Instructions.text = "Press Start to Join";
    }

    // Update is called once per frame
    void Update()
    {
        //if either keys are pressed and both toggles are off, start timer
        if (!player1Tog.isOn && !player2Tog.isOn)
        {
            //if player 1 or 2 hits start, start the timer
            if ((Input.GetKeyDown(p1Start)) || (Input.GetKeyDown(p2Start)))
            {
                timerText.text = "10";
                timerText.gameObject.SetActive(true);
                StartCoroutine(TimeOut(10));
            }
        }

        //if player 1 hit start, increment pressCount and turn on toggle
        if (Input.GetKeyDown(p1Start))
        {
            player1Tog.isOn = true;
            pressCount += 1;

            //if count is less than 2, update text to wait for another press
            if (pressCount < 2)
            {
                p1Instructions.text = "Press Start Again for Single Player";
            }
            else //otehrwise clear instructions
            {
                p1Instructions.text = "";
            }
        }
        else if (Input.GetKeyDown(p2Start))
        {
            player2Tog.isOn = true;
            pressCount += 1;

            //if count is less than 2, update text to wait for another press
            if (pressCount < 2)
            {
                p2Instructions.text = "Wait for Player 1";
            }
            else //otehrwise clear instructions
            {
                p2Instructions.text = "";
            }
        }
    }

    //this functions checks which toggles are turned on to decide which mode to play
    private void UpdateNumPlayer()
    {
        //if only single tog is on, mode is single player
        if (player1Tog.isOn && !player2Tog.isOn)
        {
            Tracker.track.isSingleMode = true;
            modeText.text = "Starting Single Player ...";
            modeText.gameObject.SetActive(true);
        }
        //if both togs are on, mode is multi player
        else if (player1Tog.isOn && player2Tog.isOn)
        {
            Tracker.track.isSingleMode = false;
            modeText.text = "Starting Multiplayer Player ...";
            modeText.gameObject.SetActive(true);
        }

        StartCoroutine(StartGame());
    }

    IEnumerator TimeOut(int seconds)
    {
        //Debug.Log("Current Seconds: " + seconds);

        //if less than 10 seconds pass, don't time out
        if ((currTime > 0) && (pressCount < 2))
        {
            yield return new WaitForSeconds(1);
            currTime -= 1;
            timerText.text = currTime.ToString();
            StartCoroutine(TimeOut(seconds -= 1));
        }
        else if ((currTime > 0) && (pressCount >= 2))
        {
            //if less than 10 seconds pass but player(s) confirm pressed, update and load
            timerText.gameObject.SetActive(false);
            p1Instructions.text = "";
            p2Instructions.text = "";
            UpdateNumPlayer();
        }
        else if (currTime <= 0)
        {
            //more than 10 seconds pass, time out & reset
            Tracker.track.isSingleMode = true;
            player1Tog.isOn = false;
            player2Tog.isOn = false;
            currTime = 10;
            pressCount = 0;
            modeText.gameObject.SetActive(false);
            timerText.gameObject.SetActive(false);
            timerText.text = "10";
            p1Instructions.text = "Press Start to Join";
            p2Instructions.text = "Press Start to Join";
        }
    }

   
    IEnumerator StartGame()
    {
        transition.SetTrigger("doFade");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("GameScene");
    }
}
