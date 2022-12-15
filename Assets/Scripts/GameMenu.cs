using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
           Application.Quit();
        }
        if(Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }
    }

}
