using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DisappearingPlatform : MonoBehaviour
{
    bool breaking;
    public float breakTime;
    public float reappearTime;
    Color c;
    TilemapRenderer sR;
    private void Start()
    {
        
        c = GetComponent<TilemapRenderer>().material.color;
        sR = GetComponent<TilemapRenderer>();
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
        sR.material.color = c;
        yield return new WaitForSeconds(breakTime / 100);
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
        sR.material.color = c;
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
        sR.material.color = new Color(c.r, c.g, c.b, 1);
        c = new Color(c.r, c.g, c.b, 1);
        breaking = false;
    }
}
