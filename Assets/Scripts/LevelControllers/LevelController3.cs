using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelController3 : MonoBehaviour
{
    public Image slider;
    public Image slider2;
    SpawnerLevel3 enemySpawner;
    AnimalMovement doggo;
    public GameObject leaver;
    public enum lvlStates
    {
        Start,
        Wave1,
        Wave2,
        Wave3,
        End,
    }
    [SerializeField]
    private lvlStates currentState=lvlStates.Start;


    private void Start()
    {
        doggo = GameObject.FindGameObjectWithTag("Player").GetComponent<AnimalMovement>();
        enemySpawner=GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnerLevel3>();
        slider2.fillAmount = 0.3f;


    }
    private void Update()
    {
        switch (currentState)
        {
            case lvlStates.Start:UpdateStartState();
                break;
            case lvlStates.Wave1:UpdateWave1();
                break;
            case lvlStates.Wave2:UpdateWave2();
                break;
            case lvlStates.Wave3:UpdateWave3();
                break;
            case lvlStates.End:UpdateEnd();
                break;
            default:
                break;
        }
    }
    //================Start=======================================
    void EnterStartState()
    {
        enemySpawner.spawnCount = 0;
        slider.fillAmount = 0;
    }
    void UpdateStartState()
    {
        SwitchState(lvlStates.Wave1);
    }
    void EndStartState()
    {
    
    }
    //=================Wave1========================================
    void EnterWave1()
    {
        enemySpawner.spawnCount = 25;
        doggo.killedEnemies = 0;
    }
    void UpdateWave1()
    {
        slider.fillAmount = doggo.killedEnemies / 25f;
        if (enemySpawner.spawnCount <= 0 && doggo.killedEnemies == 25)

        {
            
            SwitchState(lvlStates.Wave2);
        }
    }
    void EndWave1()
    {
        doggo.killedEnemies = 0;
        slider2.fillAmount = 0.7f;
    }
    //=================Wave2========================================
    void EnterWave2()
    {
        enemySpawner.spawnCount = 40;
        
    }
    void UpdateWave2()
    {
        slider.fillAmount = doggo.killedEnemies / 40f;
        if (enemySpawner.spawnCount<=0&&doggo.killedEnemies==40)
        {
            SwitchState(lvlStates.Wave3);
        }
    }
    void EndWave2()
    {
        doggo.killedEnemies = 0;
        slider2.fillAmount = 1;
    }
    //=================Wave2========================================
    void EnterWave3()
    {
        enemySpawner.spawnCount = 60;
    }
    void UpdateWave3()
    {
        slider.fillAmount = doggo.killedEnemies / 60f;
        if (enemySpawner.spawnCount<=0&&doggo.killedEnemies==60)
        {
            SwitchState(lvlStates.End);
        }
    }
    void EndWave3()
    {
        doggo.killedEnemies = 0;
    }
    //========================End=============================================
    void EnterEnd()
    {
        leaver.SetActive(true);
    }
    void UpdateEnd()
    {

    }
    void EndEnd()
    {

    }
    //======================Other================================================
    void SwitchState(lvlStates state)
    {
        switch (currentState)
        {
            case lvlStates.Start:EndStartState();
                break;
            case lvlStates.Wave1:EndWave1();
                break;
            case lvlStates.Wave2:EndWave2();
                break;
            case lvlStates.Wave3:EndWave3();
                break;
            case lvlStates.End:EndEnd();
                break;
            default:
                break;
        }
        switch (state)
        {
            case lvlStates.Start:EnterStartState();
                break;
            case lvlStates.Wave1:EnterWave1();
                break;
            case lvlStates.Wave2:EnterWave2();
                break;
            case lvlStates.Wave3:EnterWave3();
                break;
            case lvlStates.End:EnterEnd();
                break;
            default:
                break;
        }
        currentState = state;

    }
}
