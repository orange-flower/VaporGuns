using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminSettingBack : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
