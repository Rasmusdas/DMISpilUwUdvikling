using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    public float fadeTime;
    public SpriteRenderer sR;
    public bool heaven;
    public Color c;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (heaven)
            {
                other.GetComponent<Rigidbody2D>().gravityScale = 0;
                other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 15);
                Destroy(other.GetComponent<PlayerController>());
            }
            GameObject.FindGameObjectWithTag("EndGame").GetComponent<EndGameScript>().c = c;
            Debug.Log("o hai mark");
            StartCoroutine(GameObject.FindGameObjectWithTag("EndGame").GetComponent<EndGameScript>().FadeToBlack());
            
        }
    }


    IEnumerator FadeToBlack()
    {
        
        yield return new WaitForSeconds(fadeTime/100);
        sR.material.color = new Color(c.r, c.g, c.b, c.a+0.01f);
        c = sR.material.color;
        if (c.a <= 0.99)
        {
            StartCoroutine(FadeToBlack());
        }
    }
}
