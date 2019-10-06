using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    public float fadeTime;
    public SpriteRenderer sR;
    public Color c;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        { 
            GameObject.FindGameObjectWithTag("EndGame").GetComponent<EndGameScript>().c = c;
            StartCoroutine(GameObject.FindGameObjectWithTag("EndGame").GetComponent<EndGameScript>().FadeToBlack());
        }
    }


    IEnumerator FadeToBlack()
    {
        Debug.Log(c);
        yield return new WaitForSeconds(fadeTime/100);
        sR.material.color = new Color(c.r, c.g, c.b, c.a+0.01f);
        if(c.a <= 0.99)
        {
            StartCoroutine(FadeToBlack());
        }
    }
}
