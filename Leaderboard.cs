using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Text[] scoreText;
    public Text[] nameText;

    public static Leaderboard leaderboardScript;

    public Text yourScore;

    public Keyboard kbScript;

    public static int namePos;
    //private int tempScore;
    // Start is called before the first frame update
    
    void Start()
    {
        //sets up leaderboard if reseted from admin
        if (!PlayerPrefs.HasKey("singleScore1"))
        {
            PlayerPrefs.SetInt("singleScore1", 0);
            PlayerPrefs.SetInt("singleScore2", 0);
            PlayerPrefs.SetInt("singleScore3", 0);
            PlayerPrefs.SetInt("singleScore4", 0);
            PlayerPrefs.SetInt("singleScore5", 0);
        }
        if (!PlayerPrefs.HasKey("multiScore1"))
        {
            PlayerPrefs.SetInt("multiScore1", 0);
            PlayerPrefs.SetInt("multiScore2", 0);
            PlayerPrefs.SetInt("multiScore3", 0);
            PlayerPrefs.SetInt("multiScore4", 0);
            PlayerPrefs.SetInt("multiScore5", 0);
        }
        if (!PlayerPrefs.HasKey("multiName1"))
        {
            PlayerPrefs.SetString("multiName1", "");
            PlayerPrefs.SetString("multiName2", "");
            PlayerPrefs.SetString("multiName3", "");
            PlayerPrefs.SetString("multiName4", "");
            PlayerPrefs.SetString("multiName5", "");
        }
        if (!PlayerPrefs.HasKey("singleName1"))
        {
            PlayerPrefs.SetString("singleName1", "");
            PlayerPrefs.SetString("singleName2", "");
            PlayerPrefs.SetString("singleName3", "");
            PlayerPrefs.SetString("singleName4", "");
            PlayerPrefs.SetString("singleName5", "");
        }
        yourScore.text = Tracker.currentScore.ToString();
        UpdateScores();
    }

    // Update is called once per frame
    void Update()
    {
        changeText();
    }

    public void UpdateScores()
    {
        if (SceneManager.GetActiveScene().name == "EndScene")
        {
            if (Tracker.track.isSingleMode)
            {
                //single player score shuffle
                if (Tracker.currentScore > PlayerPrefs.GetInt("singleScore1"))
                {
                    //move score down
                    PlayerPrefs.SetInt("singleScore5", PlayerPrefs.GetInt("singleScore4"));
                    PlayerPrefs.SetInt("singleScore4", PlayerPrefs.GetInt("singleScore3"));
                    PlayerPrefs.SetInt("singleScore3", PlayerPrefs.GetInt("singleScore2"));
                    PlayerPrefs.SetInt("singleScore2", PlayerPrefs.GetInt("singleScore1"));
                    //move name down
                    PlayerPrefs.SetString("singleName5", PlayerPrefs.GetString("singleName4"));
                    PlayerPrefs.SetString("singleName4", PlayerPrefs.GetString("singleName3"));
                    PlayerPrefs.SetString("singleName3", PlayerPrefs.GetString("singleName2"));
                    PlayerPrefs.SetString("singleName2", PlayerPrefs.GetString("singleName1"));
                    //new score
                    PlayerPrefs.SetInt("singleScore1", Tracker.currentScore);
                    //new name
                    kbScript.kbAnim.SetBool("openKB", true);
                    namePos = 1;
                }
                else if (Tracker.currentScore > PlayerPrefs.GetInt("singleScore2"))
                {
                    //move score down
                    PlayerPrefs.SetInt("singleScore5", PlayerPrefs.GetInt("singleScore4"));
                    PlayerPrefs.SetInt("singleScore4", PlayerPrefs.GetInt("singleScore3"));
                    PlayerPrefs.SetInt("singleScore3", PlayerPrefs.GetInt("singleScore2"));
                    //move name down
                    PlayerPrefs.SetString("singleName5", PlayerPrefs.GetString("singleName4"));
                    PlayerPrefs.SetString("singleName4", PlayerPrefs.GetString("singleName3"));
                    PlayerPrefs.SetString("singleName3", PlayerPrefs.GetString("singleName2"));
                    //new score
                    PlayerPrefs.SetInt("singleScore2", Tracker.currentScore);
                    //new name
                    kbScript.kbAnim.SetBool("openKB", true);
                    namePos = 2;
                }
                else if (Tracker.currentScore > PlayerPrefs.GetInt("singleScore3"))
                {
                    //move score down
                    PlayerPrefs.SetInt("singleScore5", PlayerPrefs.GetInt("singleScore4"));
                    PlayerPrefs.SetInt("singleScore4", PlayerPrefs.GetInt("singleScore3"));
                    //move name down
                    PlayerPrefs.SetString("singleName5", PlayerPrefs.GetString("singleName4"));
                    PlayerPrefs.SetString("singleName4", PlayerPrefs.GetString("singleName3"));
                    //new score 
                    PlayerPrefs.SetInt("singleScore3", Tracker.currentScore);
                    //new name
                    kbScript.kbAnim.SetBool("openKB", true);
                    namePos = 3;
                }
                else if (Tracker.currentScore > PlayerPrefs.GetInt("singleScore4"))
                {
                    //move score down
                    PlayerPrefs.SetInt("singleScore5", PlayerPrefs.GetInt("singleScore4"));
                    //move name down
                    PlayerPrefs.SetString("singleName5", PlayerPrefs.GetString("singleName4"));
                    //new score
                    PlayerPrefs.SetInt("singleScore4", Tracker.currentScore);
                    //new name
                    kbScript.kbAnim.SetBool("openKB", true);
                    namePos = 4;
                }
                else if (Tracker.currentScore > PlayerPrefs.GetInt("singleScore5"))
                {
                    //new score
                    PlayerPrefs.SetInt("singleScore5", Tracker.currentScore);
                    //new name
                    kbScript.kbAnim.SetBool("openKB", true);
                    namePos = 5;
                }
            }
            else
            {
                //multiplayer score shuffle
                if (Tracker.currentScore > PlayerPrefs.GetInt("multiScore1"))
                {
                    //move score down
                    PlayerPrefs.SetInt("multiScore5", PlayerPrefs.GetInt("multiScore4"));
                    PlayerPrefs.SetInt("multiScore4", PlayerPrefs.GetInt("multiScore3"));
                    PlayerPrefs.SetInt("multiScore3", PlayerPrefs.GetInt("multiScore2"));
                    PlayerPrefs.SetInt("multiScore2", PlayerPrefs.GetInt("multiScore1"));
                    //move name down
                    PlayerPrefs.SetString("multiName5", PlayerPrefs.GetString("multiName4"));
                    PlayerPrefs.SetString("multiName4", PlayerPrefs.GetString("multiName3"));
                    PlayerPrefs.SetString("multiName3", PlayerPrefs.GetString("multiName2"));
                    PlayerPrefs.SetString("multiName2", PlayerPrefs.GetString("multiName1"));
                    //new score
                    PlayerPrefs.SetInt("multiScore1", Tracker.currentScore);
                    //new name
                    kbScript.kbAnim.SetBool("openKB", true);
                    namePos = 6;
                }
                else if (Tracker.currentScore > PlayerPrefs.GetInt("multiScore2"))
                {
                    //move score down
                    PlayerPrefs.SetInt("multiScore5", PlayerPrefs.GetInt("multiScore4"));
                    PlayerPrefs.SetInt("multiScore4", PlayerPrefs.GetInt("multiScore3"));
                    PlayerPrefs.SetInt("multiScore3", PlayerPrefs.GetInt("multiScore2"));
                    //move name down
                    PlayerPrefs.SetString("multiName5", PlayerPrefs.GetString("multiName4"));
                    PlayerPrefs.SetString("multiName4", PlayerPrefs.GetString("multiName3"));
                    PlayerPrefs.SetString("multiName3", PlayerPrefs.GetString("multiName2"));
                    //new score
                    PlayerPrefs.SetInt("multiScore2", Tracker.currentScore);
                    //new name
                    kbScript.kbAnim.SetBool("openKB", true);
                    namePos = 7;
                }
                else if (Tracker.currentScore > PlayerPrefs.GetInt("multiScore3"))
                {
                    //move score down
                    PlayerPrefs.SetInt("multiScore5", PlayerPrefs.GetInt("multiScore4"));
                    PlayerPrefs.SetInt("multiScore4", PlayerPrefs.GetInt("multiScore3"));
                    //move name down
                    PlayerPrefs.SetString("multiName5", PlayerPrefs.GetString("multiName4"));
                    PlayerPrefs.SetString("multiName4", PlayerPrefs.GetString("multiName3"));
                    //new score
                    PlayerPrefs.SetInt("multiScore3", Tracker.currentScore);
                    //new name
                    kbScript.kbAnim.SetBool("openKB", true);
                    namePos = 8;
                }
                else if (Tracker.currentScore > PlayerPrefs.GetInt("multiScore4"))
                {
                    //move score down
                    PlayerPrefs.SetInt("multiScore5", PlayerPrefs.GetInt("multiScore4"));
                    //move name down
                    PlayerPrefs.SetString("multiName5", PlayerPrefs.GetString("multiName4"));
                    //new score
                    PlayerPrefs.SetInt("multiScore4", Tracker.currentScore);
                    //new name
                    kbScript.kbAnim.SetBool("openKB", true);
                    namePos = 9;
                }
                else if (Tracker.currentScore > PlayerPrefs.GetInt("multiScore5"))
                {
                    PlayerPrefs.SetInt("multiScore5", Tracker.currentScore);
                    //new name
                    kbScript.kbAnim.SetBool("openKB", true);
                    namePos = 10;
                }
            }
            changeText();
        }
    }

    public void changeText()
    {
        if (Tracker.track.isSingleMode)
        {
            //update single name text and score
            nameText[0].text = PlayerPrefs.GetString("singleName1");
            nameText[1].text = PlayerPrefs.GetString("singleName2");
            nameText[2].text = PlayerPrefs.GetString("singleName3");
            nameText[3].text = PlayerPrefs.GetString("singleName4");
            nameText[4].text = PlayerPrefs.GetString("singleName5");
            scoreText[0].text = PlayerPrefs.GetInt("singleScore1").ToString();
            scoreText[1].text = PlayerPrefs.GetInt("singleScore2").ToString();
            scoreText[2].text = PlayerPrefs.GetInt("singleScore3").ToString();
            scoreText[3].text = PlayerPrefs.GetInt("singleScore4").ToString();
            scoreText[4].text = PlayerPrefs.GetInt("singleScore5").ToString();
        } 
        else
        {
            //update multi name text and score
            nameText[0].text = PlayerPrefs.GetString("multiName1");
            nameText[1].text = PlayerPrefs.GetString("multiName2");
            nameText[2].text = PlayerPrefs.GetString("multiName3");
            nameText[3].text = PlayerPrefs.GetString("multiName4");
            nameText[4].text = PlayerPrefs.GetString("multiName5");
            scoreText[0].text = PlayerPrefs.GetInt("multiScore1").ToString();
            scoreText[1].text = PlayerPrefs.GetInt("multiScore2").ToString();
            scoreText[2].text = PlayerPrefs.GetInt("multiScore3").ToString();
            scoreText[3].text = PlayerPrefs.GetInt("multiScore4").ToString();
            scoreText[4].text = PlayerPrefs.GetInt("multiScore5").ToString();
        }   
    }
}
