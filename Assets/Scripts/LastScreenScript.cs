using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()

    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene(0);
        }

    }
}
