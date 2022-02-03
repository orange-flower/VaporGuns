using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupExit : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene(3);
    }
}
