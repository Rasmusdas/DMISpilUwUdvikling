using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBridge : MonoBehaviour
{
    public Vector3 spawnPoint;
    public GameObject bridge;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bridge.SetActive(true);
        collision.transform.position = spawnPoint;
        Camera.main.backgroundColor = Color.black;
    }
}
