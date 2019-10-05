using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public GameObject oldCam;
    public GameObject newCam;
    private void OnTriggerEnter(Collider other)
    {
        newCam.SetActive(true);
        oldCam.SetActive(false);
    }
}
