using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelController1 : MonoBehaviour
{   
    public float enemiesLeft;
    public Image sliderWave;
    public Image slider;
    SpawnerLevel1 enemySpawner;
    Parrotto parot;
    public GameObject window;
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
        sliderWave.fillAmount = 0.3f;
        parot = GameObject.FindGameObjectWithTag("Player").GetComponent<Parrotto>();
        enemySpawner=GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnerLevel1>();


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
        enemySpawner.spawnCount = 10;
        parot.killedEnemies = 0;
        enemySpawner.spawnRange = 5;
    }
    void UpdateWave1()
    {
        slider.fillAmount = parot.killedEnemies / 10f;
        if (enemySpawner.spawnCount <= 0 && parot.killedEnemies == 10)

        {
            
            SwitchState(lvlStates.Wave2);
        }
    }
    void EndWave1()
    {
        parot.killedEnemies = 0;
        sliderWave.fillAmount = 0.7f;
    }
    //=================Wave2========================================
    void EnterWave2()
    {
        enemySpawner.spawnCount = 20;
        enemySpawner.spawnRange = 3;
        
    }
    void UpdateWave2()
    {
        slider.fillAmount = parot.killedEnemies / 20f;
        if (enemySpawner.spawnCount<=0&&parot.killedEnemies==20)
        {
            SwitchState(lvlStates.Wave3);
        }
    }
    void EndWave2()
    {
        parot.killedEnemies = 0;
        sliderWave.fillAmount = 1;
    }
    //=================Wave2========================================
    void EnterWave3()
    {
        enemySpawner.spawnCount = 30;
        enemySpawner.spawnRange = 2;
    }
    void UpdateWave3()
    {
        slider.fillAmount = parot.killedEnemies / 30f;
        if (enemySpawner.spawnCount<=0&&parot.killedEnemies==30)
        {
            SwitchState(lvlStates.End);
        }
    }
    void EndWave3()
    {
        parot.killedEnemies = 0;
    }
    //========================End=============================================
    void EnterEnd()
    {
        window.SetActive(true);
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
