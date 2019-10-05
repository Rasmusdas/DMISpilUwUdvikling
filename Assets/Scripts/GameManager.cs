using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector2 spawnPoint;
    public GameObject player;

    // Update is called once per frame
    private void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        Instantiate(player, spawnPoint, Quaternion.identity);
    }
}
