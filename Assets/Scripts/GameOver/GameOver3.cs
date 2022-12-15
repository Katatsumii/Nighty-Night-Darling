using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver3 : MonoBehaviour
{ 
    public GameObject gameOverScreen;
    LoadingScreenScript loadingScreenScript;
    // Start is called before the first frame update
    void Start()
    {
       
        loadingScreenScript =GameObject.Find("LevelLoader").GetComponent<LoadingScreenScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOverScreen.activeInHierarchy)
        {
           
            if(Input.GetKey(KeyCode.Escape))
            {
                loadingScreenScript.LoadScene(0);
            }
            if(Input.GetKey(KeyCode.Return))
            {
                loadingScreenScript.LoadScene(8);
            }

        }   
      
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Clown"))
        {
            gameOverScreen.SetActive(true);
        }
    }
}
