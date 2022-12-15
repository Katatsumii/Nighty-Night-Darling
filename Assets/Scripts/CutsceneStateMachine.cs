using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneStateMachine : MonoBehaviour
{
    public LoadingScreenScript loading;
    public GameObject text;
    public Animator Cutscene0;
    public Animator Cutscene1;
    public Animator Cutscene2;
    public Animator Cutscene3;
    public Animator Cutscene4;
    public Animator Cutscene5;
    public Animator Cutscene6;
    public Animator Cutscene7;
    public GameObject textBox;
    cutscene currentstate;
    enum cutscene
    {
        state0,
        state1,
        state2,
        state3,
        state4,
        state5,
        state6,
        state7
    }
    void Start()
    {
        currentstate = cutscene.state0;
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentstate)
        {
            case cutscene.state0:state0Update();
                break;
            case cutscene.state1:state1Update();
                break;
            case cutscene.state2: state2Update();
                break;
            case cutscene.state3: state3Update();
                break;
            case cutscene.state4: state4Update();
                break;
            case cutscene.state5: state5Update();
                break;
            case cutscene.state6: state6Update();
                break;
            case cutscene.state7: state7Update();
                break;
        }
    }
    void state0Start()
    {

    }
    void state0Update()
    {
        StartCoroutine(start());
    }
    void state0End()
    {

    }
    //=====state1======
    void state1Start()
    {
        textBox.SetActive(true);
    }
    void state1Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Cutscene1.SetTrigger("Go");
            SwitchState(cutscene.state2);
            
        }
    }
    void state1End()
    {

    }
    //=====state2======
    void state2Start()
    {

    }
    void state2Update()
    {
        StartCoroutine(second5());
       // if (Input.GetButtonDown("Fire1"))
       // {
           // Cutscene2.SetTrigger("Go");
           // SwitchState(cutscene.state3);

       // }
    }
    void state2End()
    {

    }
    //===state3====
    void state3Start()
    {

    }
    void state3Update()
    {
        StartCoroutine(second4());
       // if (Input.GetButtonDown("Fire1"))
      //  {
      //      Cutscene3.SetTrigger("Go");
        //    SwitchState(cutscene.state4);

       // }
    }
    void state3End()
    {

    }
    //======state4=====
    void state4Start()
    {

    }
    void state4Update()
    {
        StartCoroutine(second());   
    }
    void state4End()
    {

    }
    //=====state5=====
    void state5Start()
    {

    }
    void state5Update()
    {
        StartCoroutine(second2());
        //if (Input.GetButtonDown("Fire1"))
       // {
       //     Cutscene5.SetTrigger("Go");
       //     SwitchState(cutscene.state6);

      //  }
    }
    void state5End()
    {

    }
    //====state6===
    void state6Start()
    {

    }
    void state6Update()
    {
        StartCoroutine (second3());
       // if (Input.GetButtonDown("Fire1"))
        //{
         //   Cutscene6.SetTrigger("Go");
         //   SwitchState(cutscene.state7);

       // }
    }
    void state6End()
    {

    }
    //====state7====
    void state7Start()
    {
        text.SetActive(true);
    }
    void state7Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            loading.LoadScene(2);
        }
    }
    void state7End()
    {

    }
    //====other====
    void SwitchState(cutscene state)
    {
        switch(currentstate)
        {
             case cutscene.state0:state0End();
                break;
             case cutscene.state1:state1End();
                break;
            case cutscene.state2:state2End();
                break;
            case cutscene.state3:state3End();
                break;
            case cutscene.state4:state4End();
                break;
            case cutscene.state5:state5End();
                break;
            case cutscene.state6:state6End();
                break;
            case cutscene.state7:state7End();
                break;  
        }
        switch (state)
        {
            case cutscene.state0: state0Start();
                break;
            case cutscene.state1:state1Start();
                break;
            case cutscene.state2:state2Start();
                break;
            case cutscene.state3:state3Start();
                break;
            case cutscene.state4:state4Start();
                break;
            case cutscene.state5:state5Start();
                break;
            case cutscene.state6:state6Start();
                break;
            case cutscene.state7:state7Start();
                break;
        }
        currentstate = state;
    }
   IEnumerator second()
    {
        yield return new WaitForSeconds(0.8f);
        Cutscene4.SetTrigger("Go");
        SwitchState(cutscene.state5);
        yield return new WaitForSeconds(0.8f);
    }
    IEnumerator second2()
    {
        yield return new WaitForSeconds(0.8f);
        Cutscene5.SetTrigger("Go");
        yield return new WaitForSeconds(0.8f);
        SwitchState(cutscene.state6);
    }
    IEnumerator second3()
    {
       
        Cutscene6.SetTrigger("Go");
        SwitchState(cutscene.state7);
        yield return new WaitForSeconds(0.8f); 
    }
    IEnumerator second4()
    {
        yield return new WaitForSeconds(0.8f);
        Cutscene3.SetTrigger("Go");
        yield return new WaitForSeconds(0.8f);
        SwitchState(cutscene.state4);
    }
    IEnumerator second5()
    {
        yield return new WaitForSeconds(0.8f);
        Cutscene2.SetTrigger("Go");
        yield return new WaitForSeconds(0.8f);
        SwitchState(cutscene.state3);
    }

    IEnumerator start()
    {
        Cutscene0.SetTrigger("Black");
        yield return new WaitForSeconds(1);
        Cutscene0.SetTrigger("Go");
        yield return new WaitForSeconds(0.5f);
        SwitchState(cutscene.state1);


    }
}

