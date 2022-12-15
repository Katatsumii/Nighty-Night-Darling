using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class BGM : MonoBehaviour
{
    public static BGM instance;

    void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else if (SceneManager.GetSceneByName("BossFight").isLoaded)
        {
            Destroy(gameObject);
        }
        else

        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
       
    }
}