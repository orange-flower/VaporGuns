using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminKey : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) 
        {
                    SceneManager.LoadScene("AdminSettings");
        }          
    }
}