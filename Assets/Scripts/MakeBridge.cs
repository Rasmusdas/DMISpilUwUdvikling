using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBridge : MonoBehaviour
{
    public Vector3 spawnPoint;
    public GameObject bridge;
    public GameObject player;
    public Material owo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        bridge.SetActive(true);
        Instantiate(player, spawnPoint,Quaternion.identity);
        collision.gameObject.GetComponent<PlayerController>().control = false;
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }
}
