using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    public static Tracker track;
    public bool isSingleMode;

    //score stuff
    public static int currentScore;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        if (track == null)
        {
            track = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}
