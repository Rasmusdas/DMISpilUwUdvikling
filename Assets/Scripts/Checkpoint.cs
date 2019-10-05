using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ey  yo");
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().spawnPoint = gameObject.transform.position;
    }
}
