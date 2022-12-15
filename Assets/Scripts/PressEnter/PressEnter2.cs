using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressEnter2 : MonoBehaviour
{
    public LoadingScreenScript script;
   
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Return))
        {
            script.LoadScene(8);
        }
    }
}
