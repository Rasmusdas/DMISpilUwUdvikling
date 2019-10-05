using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject newCam;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(!newCam.activeSelf && other.tag == "Player")
        {
            Camera.main.gameObject.SetActive(false);
            newCam.SetActive(true);
        }
    }
}
