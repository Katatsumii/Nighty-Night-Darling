using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject slider;
    LoadingScreenScript loadingScreenScript;
    // Start is called before the first frame update
    void Start()
    {
        loadingScreenScript =GameObject.Find("LevelLoader").GetComponent<LoadingScreenScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverScreen.activeInHierarchy == true)
        {
            if(Input.GetKey(KeyCode.Escape))
            {
                loadingScreenScript.LoadScene(0);
            }
            if(Input.GetKey(KeyCode.Return))
            {
                loadingScreenScript.LoadScene(2);
            }

        }    
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            slider.SetActive(false);
            gameOverScreen.SetActive(true);
        }
    }
}
