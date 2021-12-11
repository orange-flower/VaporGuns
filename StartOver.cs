using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartOver : MonoBehaviour
{
    public Text nextText;
    public Text modeText;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        //change title based on mode
        if (Tracker.track.isSingleMode)
        {
            modeText.text = "Single Player LeaderBoard";
        }
        else
        {
            modeText.text = "Multiplayer LeaderBoard";
        }
    }

    // Update is called once per frame
    void Update()
    {
        //hit start to load main menu again
       // if (nextText.IsActive())
       //{
            if ((Input.GetKeyDown(KeyCode.Q)) || (Input.GetKeyDown(KeyCode.P)))
            {
                SceneManager.LoadScene("MenuScene");
            }
       //}
    }
}
