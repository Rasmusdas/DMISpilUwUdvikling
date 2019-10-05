using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    bool breaking;
    public float breakTime;
    public float reappearTime;
    Color c;
    SpriteRenderer sR;
    private void Start()
    {
        c = GetComponent<SpriteRenderer>().color;
        sR = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player" && !breaking )
        {
            breaking = true;
            StartCoroutine(BreakPlatform());
        }
    }

    IEnumerator BreakPlatform()
    {
        
        c = new Color(c.r,c.g,c.b,c.a-0.05f);
        sR.color = c;
        yield return new WaitForSeconds(breakTime / 100);
        Debug.Log(c.a);
        if (c.a > 0.01)
        {
            StartCoroutine(BreakPlatform());
        }
        else
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
            yield return new WaitForSeconds(reappearTime);
            StartCoroutine(RebuildPlatform());
        }
    }
    IEnumerator RebuildPlatform()
    {
        c = new Color(c.r, c.g, c.b, c.a + 0.05f);
        sR.color = c;
        yield return new WaitForSeconds(breakTime / 100);
        if (c.a > 0.95)
        {
            PlacePlatform();
        }
        else
        {
            StartCoroutine(RebuildPlatform());
        }
        
    }

    void PlacePlatform()
    {
        GetComponent<BoxCollider2D>().isTrigger = false;
        sR.color = new Color(c.r, c.g, c.b, 1);
        c = new Color(c.r, c.g, c.b, 1);
        breaking = false;
    }
}
