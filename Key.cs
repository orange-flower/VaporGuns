using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public string letter;
    public Text reponseText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    //on key press, check what key is pressed
    public string KeyPressed(string name)
    {
        //if it's a letter, add it to the name
        if ((letter != "Clear") && (letter != "Confirm") && (letter != "Delete"))
        {
            name += letter;
        }
        //if it's clear, set it to empty string
        else if (letter == "Clear")
        {
            name = "";
        }
        //if it's delete, take off last letter
        else if (letter == "Delete")
        {
            if (name.Length >= 1)
            {
                name = name.Remove(name.Length - 1);
            }
        }
        //if it's confirm, validate length first
        else if (letter == "Confirm")
        {
            //check if 4 letters or less
            if (name.Length > 4)
            {
                //if more than 4, inform player
                reponseText.text = "Name maximum is 4 characters";
            }
            else if (name.Length == 0)
            {
                //if submitting nothing, inform player
                reponseText.text = "Name field is blank";
            }
            else 
            {
                //otherwise submit score
                reponseText.text = "Name & score submitted";
                Keyboard.kb.nameSubmitted = true;
            }
        }

        //return the string name
        return name;
    }
}
