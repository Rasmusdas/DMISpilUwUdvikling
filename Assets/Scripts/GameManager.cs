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
        Screen.SetResolution(1920,1200, true);
    }

    public void SpawnPlayer()
    {
        Instantiate(player, spawnPoint, Quaternion.identity);
    }
}
