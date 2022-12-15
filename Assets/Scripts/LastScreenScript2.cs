using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastScreenScript2 : MonoBehaviour
{

    LastScreenScript lastscreen;
    private void Start()
    {
        lastscreen = GetComponent<LastScreenScript>();
    }

    void enableScript()
    {
        lastscreen.enabled = true;
    }

}
