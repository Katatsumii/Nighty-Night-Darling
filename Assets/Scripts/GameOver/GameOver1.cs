using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver1 : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject slider;
    public GameObject slider2;
    LoadingScreenScript loadingScreenScript;
    // Start is called before the first frame update
    void Start()
    {
        loadingScreenScript =GameObject.Find("LevelLoader").GetComponent<LoadingScreenScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverScreen.activeInHierarchy==true)
        {
            if(Input.GetKey(KeyCode.Escape))
            {
                loadingScreenScript.LoadScene(0);
            }
            if(Input.GetKey(KeyCode.Return))
            {
                loadingScreenScript.LoadScene(4);
            }

        }    
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            gameOverScreen.SetActive(true);
            slider.SetActive(false);
            slider2.SetActive(false);
        }
    }
}
