using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerAndCorpses : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<PlayerController>().KillPlayer();
        foreach (var item in GameObject.FindGameObjectsWithTag("Dead"))
        {
            Destroy(item);
        }
    }
}
