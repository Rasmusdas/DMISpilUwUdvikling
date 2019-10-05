using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public Vector3 spawnPoint;
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(player, spawnPoint,Quaternion.identity);
        collision.gameObject.GetComponent<PlayerController>().control = false;
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
    }
}
