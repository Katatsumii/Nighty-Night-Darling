using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver4 : MonoBehaviour
{
    DoggoBattle doggo;
    public GameObject gameOverScreen;
    public GameObject hpBoss;
    public GameObject hpDog;
    LoadingScreenScript loadingScreenScript;
    // Start is called before the first frame update
    void Start()
    {
        doggo = GameObject.Find("Square").GetComponent<DoggoBattle>();
        loadingScreenScript = GameObject.Find("LevelLoader").GetComponent<LoadingScreenScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverScreen.activeInHierarchy)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                loadingScreenScript.LoadScene(0);
            }
            if (Input.GetKey(KeyCode.Return))
            {
                loadingScreenScript.LoadScene(8);
            }

        }
        if (doggo.hp == 0)
        {
            hpBoss.SetActive(false);
            hpDog.SetActive(false);
            gameOverScreen.SetActive(true);
        }

    }
}
