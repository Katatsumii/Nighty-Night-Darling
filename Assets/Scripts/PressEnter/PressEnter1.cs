using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressEnter1 : MonoBehaviour
{
    public LoadingScreenScript script;
   
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Return))
        {
            script.LoadScene(6);
        }
    }
}
