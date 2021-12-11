using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //deletes scores and names in the player prefs
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
