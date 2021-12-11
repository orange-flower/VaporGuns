using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour
{
    public static Keyboard kb;

    //arrays
    public List<Button> row0;
    public List<Button> row1;
    public List<Button> row2;
    public List<Button> row3;
    public List<List<Button>> keyboardArr = new List<List<Button>>();
    
    //UI elements
    private Button selectedButton;
    public InputField nameField;
    public Text nextText;
    public Text responseText;

    //other
    private int columnIdx;
    private int rowIdx;
    public bool nameSubmitted;
    public Animator kbAnim;

    //leaderboard script

    // Start is called before the first frame update
    void Start()
    {
        kb = this;

        nameSubmitted = false;

        //add rows to the keyboard list
        keyboardArr.Add(row0);
        keyboardArr.Add(row1);
        keyboardArr.Add(row2);
        keyboardArr.Add(row3);

        //start off on the q key
        columnIdx = 0;
        rowIdx = 1;
        selectedButton = keyboardArr[rowIdx][columnIdx];
        SelectButton(selectedButton);

        //change info text depending on mode
        if(Tracker.track.isSingleMode)
        {
            responseText.text = "Enter your name";
        }
        else
        {
            responseText.text = "Enter your team name";
        }
        
        //start name blank
        nameField.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            //use the horizontal and vertical of player one to type
            KeyboardScroll("Horizontal1", "Vertical1");

            //if shoot button is pressed, call Key's keyPressed function
            if (Input.GetKeyDown(KeyCode.B))
            {
                //save name into the input field
                nameField.text = selectedButton.GetComponent<Key>().KeyPressed(nameField.text);
                
                //if name is submitted, update text
                if (nameSubmitted)
                {
                    if (Leaderboard.namePos == 1) { PlayerPrefs.SetString("singleName1", nameField.text); }
                    else if (Leaderboard.namePos == 2) { PlayerPrefs.SetString("singleName2", nameField.text); }
                    else if (Leaderboard.namePos == 3) { PlayerPrefs.SetString("singleName3", nameField.text); }
                    else if (Leaderboard.namePos == 4) { PlayerPrefs.SetString("singleName4", nameField.text); }
                    else if (Leaderboard.namePos == 5) { PlayerPrefs.SetString("singleName5", nameField.text); }
                    else if (Leaderboard.namePos == 6) { PlayerPrefs.SetString("multiName1", nameField.text); }
                    else if (Leaderboard.namePos == 7) { PlayerPrefs.SetString("multiName2", nameField.text); }
                    else if (Leaderboard.namePos == 8) { PlayerPrefs.SetString("multiName3", nameField.text); }
                    else if (Leaderboard.namePos == 9) { PlayerPrefs.SetString("multiName4", nameField.text); }
                    else if (Leaderboard.namePos == 10) { PlayerPrefs.SetString("multiName5", nameField.text); }

                    //put away keyboard
                    //Debug.Log("hu");
                    kbAnim.SetBool("openKB", false);

                    StartCoroutine(DelayText(nextText));
                }
            }
        }
    }

    //this function takes in the hor and vert to change key
    public void KeyboardScroll(string hor, string vert)
    {
        float h = Input.GetAxis(hor);
        float v = Input.GetAxis(vert);

        //if hor is greater than 0, deselect and move right
        if (h > 0)
        {
            DeselectButton(selectedButton);
            UpdateColumn(1, keyboardArr[rowIdx]);
            selectedButton = keyboardArr[rowIdx][columnIdx];
        }
        //if hor is less than 0, deselect and move left
        else if (h < 0)
        {
            DeselectButton(selectedButton);
            UpdateColumn(-1, keyboardArr[rowIdx]);
            selectedButton = keyboardArr[rowIdx][columnIdx];            
        }

        //if vert is greater than 0, deselect and move up
        if (v < 0)
        {
            DeselectButton(selectedButton);
            UpdateRow(1);
        }
        //if vert is less than 0, deselect and move down
        else if (v > 0)
        {
            DeselectButton(selectedButton);
            UpdateRow(-1);
        }

        //update key
        selectedButton = keyboardArr[rowIdx][columnIdx];
        SelectButton(selectedButton);
    }

    //this function turns on outline
    public void SelectButton(Button currButton)
    {
        //enable outline
        currButton.GetComponent<Outline>().enabled = true;
    }

    //this function turns off outline
    public void DeselectButton(Button currButton)
    {
        //disable outline
        currButton.GetComponent<Outline>().enabled = false;
    }

    //this function changes the row number
    public void UpdateRow(int increment)
    {
        rowIdx += increment;

        //if next row is row1 and col is greated than idx 1, zone the first 4 keys to the left (clear button)
        //and the right 5 keys to the right (confirm button)
        if ((rowIdx == 0) && (columnIdx >= 1))
        {
            if (columnIdx < 5)
            {
                columnIdx = 0;
            }
            else if (columnIdx >= 5)
            {
                columnIdx = 1;
            }
        }
        //if the next row is row1 and the curr col is idx 1, make it go down to the last key of row1
        else if (rowIdx == 1)
        {
            if (columnIdx == 1)
            {
                columnIdx = keyboardArr[rowIdx].Count - 1;
            }
        }

        //check if out of bounds
        if (rowIdx >= keyboardArr.Count - 1)
        {
            rowIdx = keyboardArr.Count - 1;
        }
        else if (rowIdx <= 0)
        {
            rowIdx = 0;
        }

        //Debug.Log("New row idx: " + rowIdx);
    }

    //this function changes the col number
    public void UpdateColumn(int increment, List<Button> rowArr)
    {
        columnIdx += increment;

        //check if out of bounds
        if (columnIdx >= rowArr.Count - 1)
        {
            columnIdx = (rowArr.Count - 1);
        }
        else if (columnIdx <= 0)
        {
            columnIdx = 0;
        }

        //Debug.Log("New col idx: " + columnIdx);
    }

    //this function delays showing the start text
    IEnumerator DelayText(Text text)
    {
        yield return new WaitForSeconds(2);
        text.gameObject.SetActive(true);
    }
}
