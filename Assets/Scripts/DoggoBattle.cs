using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoggoBattle : MonoBehaviour
{ public float hp = 3;
    SpriteRenderer sr;
    public Image fill;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Physics2D.IgnoreLayerCollision(11, 7,false);
    }
    private void Update()
    {
        switch(hp)
        {
            case 3: fill.fillAmount = 1;
                break;
            case 2:fill.fillAmount = 0.650f;
                break;
            case 1:fill.fillAmount = 0.350f;
                break;
            case 0:fill.fillAmount = 0;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            hp--;
            StartCoroutine(doggoImmortal());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Clown"))
        {
            hp--;
            StartCoroutine(doggoImmortal());
        }
    }
    IEnumerator doggoImmortal()
    {
        Physics2D.IgnoreLayerCollision(11, 7, true);
        for (int i = 0; i < 2; i++)
        {
            sr.color = new Color(1, 0, 0, 0.75f);
            yield return new WaitForSeconds(0.35f);
            sr.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(0.35f);
        }

        sr.color = Color.white;
        Physics2D.IgnoreLayerCollision(11,7,false);
    }
}
