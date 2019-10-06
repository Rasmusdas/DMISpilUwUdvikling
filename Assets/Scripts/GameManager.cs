﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector2 spawnPoint;
    public GameObject player;
    public static int timesDied;

    public void SpawnPlayer()
    {
        var temp = Instantiate(player, spawnPoint, Quaternion.identity);
        temp.GetComponent<AudioSource>().Play();
        GameManager.timesDied++;
    }
}
