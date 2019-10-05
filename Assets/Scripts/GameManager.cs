using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector2 spawnPoint;
    public GameObject player;
    public static int timesDied;

    public void SpawnPlayer()
    {
        Instantiate(player, spawnPoint, Quaternion.identity);
        GameManager.timesDied++;
    }
}
