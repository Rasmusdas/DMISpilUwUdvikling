using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().spawnPoint = gameObject.transform.position; // Daniel i hate this line :(
    }
}
