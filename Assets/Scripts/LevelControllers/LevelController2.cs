using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelController2 : MonoBehaviour
{
    public Image slider;
    public Image waveSlider;
    SpawnerLevel2 enemySpawner;
    AnimalMovement2 kotel;
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
        kotel = GameObject.FindGameObjectWithTag("Player").GetComponent<AnimalMovement2>();
        enemySpawner=GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnerLevel2>();
        waveSlider.fillAmount = 0.3f;


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
        enemySpawner.spawnRange = 5;
        enemySpawner.spawnCount = 25;
        kotel.killedEnemies = 0;
    }
    void UpdateWave1()
    {
        slider.fillAmount = kotel.killedEnemies / 25f;
        if (enemySpawner.spawnCount <= 0 && kotel.killedEnemies == 25)

        {
            
            SwitchState(lvlStates.Wave2);
        }
    }
    void EndWave1()
    {
        kotel.killedEnemies = 0;
        waveSlider.fillAmount = 0.7f;
    }
    //=================Wave2========================================
    void EnterWave2()
    {
        enemySpawner.spawnCount = 40;
        enemySpawner.spawnRange = 4;

    }
    void UpdateWave2()
    {
        slider.fillAmount = kotel.killedEnemies / 40f;
        if (enemySpawner.spawnCount<=0&&kotel.killedEnemies==40)
        {
            SwitchState(lvlStates.Wave3);
        }
    }
    void EndWave2()
    {
       kotel.killedEnemies = 0;
        waveSlider.fillAmount = 1;
    }
    //=================Wave2========================================
    void EnterWave3()
    {
        enemySpawner.spawnCount = 55;
        enemySpawner.spawnRange = 4;
    }
    void UpdateWave3()
    {
        slider.fillAmount = kotel.killedEnemies / 55f;
        if (enemySpawner.spawnCount<=0&&kotel.killedEnemies==55)
        {
            SwitchState(lvlStates.End);
        }
    }
    void EndWave3()
    {
        kotel.killedEnemies = 0;
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
