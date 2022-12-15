using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossFightController : MonoBehaviour
{   public lvlState currentState;
    public CircleCollider2D blueBaloonCollider;
    public CircleCollider2D redBaloonCollider;
    public CircleCollider2D yellowBaloonCollider;
    public GameObject kotel;
    public GameObject parotka;
    public GameObject platform;
    public GameObject dogHp;
    public GameObject puzzle;
    public GameObject baloon;
    public GameObject bgm1;
    public GameObject bgm2;
    GameObject audioSource;
    FirstStageScript firstStageScript;
    SecondStageScript secondStageScript;
    ThirdStageScript thirdStageScript;
    FinalStageScript finalStageScript;
    BlueBaloonScript blueBaloonScript;
    RedBallonScript redBaloonScript;
    YellowBaloonScript yellowBaloonScript;
    Parrotto parot;
    AfterBaloon cat2;
    AfterBaloonParot parot2;
    AnimalMovement3 cat;
    AnimalMovement1 dog;
    DoggoBattle dog2;
    DoggoAttack dog3;
    public GameObject door;
    public GameObject door2;
    public GameObject door3;
    FlyAwayScript flyAway;
    
    public enum lvlState
    {
        Stage1,
        Stage2,
        Stage3,
        FinalStage,
    }
    private void Start()
    {
        audioSource = GameObject.Find("AudioSource");
        Destroy(audioSource);
        dog = GameObject.Find("Square").GetComponent<AnimalMovement1>();
        dog2=GameObject.Find("Square").GetComponent<DoggoBattle>();
        dog3= GameObject.Find("Square").GetComponent<DoggoAttack>();
        cat = GameObject.Find("Kotel").GetComponent<AnimalMovement3>();
        cat2= GameObject.Find("Kotel").GetComponent<AfterBaloon>();
        parot = GameObject.Find("Parrot").GetComponent<Parrotto>();
        parot2 = GameObject.Find("Parrot").GetComponent<AfterBaloonParot>();
        firstStageScript =GameObject.FindGameObjectWithTag("Clown").GetComponent<FirstStageScript>();
        secondStageScript = GameObject.FindGameObjectWithTag("Clown").GetComponent<SecondStageScript>();
        thirdStageScript = GameObject.FindGameObjectWithTag("Clown").GetComponent<ThirdStageScript>();
        finalStageScript = GameObject.FindGameObjectWithTag("Clown").GetComponent<FinalStageScript>();
        blueBaloonScript=GameObject.FindGameObjectWithTag("Blue Baloon").GetComponent<BlueBaloonScript>();
        redBaloonScript = GameObject.FindGameObjectWithTag("Red Baloon").GetComponent<RedBallonScript>();
        yellowBaloonScript = GameObject.FindGameObjectWithTag("Yellow Baloon").GetComponent<YellowBaloonScript>();
        currentState = lvlState.Stage1;
        redBaloonCollider.enabled = false;
        yellowBaloonCollider.enabled = false;
        flyAway = GameObject.FindGameObjectWithTag("Clown").GetComponent <FlyAwayScript>();
    }
    private void Update()
    {
        switch (currentState)
        {
            case lvlState.Stage1: UpdateStage1();
                break;
            case lvlState.Stage2: UpdateStage2();
                break;
            case lvlState.Stage3: UpdateStage3();
                break;
            case lvlState.FinalStage:UpdateFinalStage();
                break;
        }
    }
    //======STAGE1=====
    void StartStage1()
    {
    }
    void UpdateStage1()
    {
        if (blueBaloonScript.blueBaloonDestroyed == true)
        {
            flyAway.FlyAway();   
            ChangeStage(lvlState.Stage2);
        }


    }
    void EndStage1()
    {
        parot.enabled = false;
        firstStageScript.enabled = false;
        door.SetActive(false);
        parot2.enabled = true;
    }
    //======STAGE2=====
    void StartStage2()
    {
        cat.enabled = true;
        redBaloonCollider.enabled = true;
        door2.SetActive(true);
        secondStageScript.enabled = true;
    }
    void UpdateStage2()
    {
        if(redBaloonScript.redBaloonDestroyed==true)
        {
            flyAway.FlyAway();
            ChangeStage(lvlState.Stage3);
        }
    }
    void EndStage2()
    {
        cat.enabled = false;
        cat2.enabled = true;
        secondStageScript.enabled=false;
        door2.SetActive(false);
    }
    //======STAGE3=====
    void StartStage3()
    {
        Destroy(parotka);
        dog.enabled = true;
        dog3.enabled = true;
        yellowBaloonCollider.enabled = true;
        door3.SetActive(true);
        thirdStageScript.enabled = true;
    }
    void UpdateStage3()
    {   if(yellowBaloonScript.yellowBaloonDestroyed==true)
        {
        ChangeStage(lvlState.FinalStage);
        }
    }
    void EndStage3()
    {
        thirdStageScript.enabled = false;
        bgm1.SetActive(false);
    }
    //======FinalStage=====
    void StartFinalStage()
    {   dog2.enabled = true;
        bgm2.SetActive(true);
        baloon.SetActive(false);
        Destroy(kotel);
        finalStageScript.enabled = true;
        dogHp.SetActive(true);
        door3.SetActive(false);
        
    }
    void UpdateFinalStage()
    {
        if (finalStageScript.clownIsDead == true)
        {
            puzzle.SetActive(true);
        }
    }
    void EndFinalStage()
    {

    }
    //======Other=====
    void ChangeStage(lvlState state)
    {
        switch (currentState)
        {
            case lvlState.Stage1: EndStage1();     break;
            case lvlState.Stage2: EndStage2();     break;  
            case lvlState.Stage3: EndStage3();    break;
            case lvlState.FinalStage: EndFinalStage();  break;
        }
        switch (state)
        {
            case lvlState.Stage1:       StartStage1(); break;
            case lvlState.Stage2:       StartStage2(); break;
            case lvlState.Stage3:       StartStage3(); break;
            case lvlState.FinalStage:   StartFinalStage(); break;
        }
        currentState = state;
    }

}

