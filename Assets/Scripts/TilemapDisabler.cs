using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapDisabler : MonoBehaviour
{

    public GameObject tileToDisable;
    public GameObject tileToEnable;
    public int requiredDeaths;
    void Update()
    {
        if(requiredDeaths <= GameManager.timesDied && !tileToEnable.activeSelf)
        {
            tileToDisable.SetActive(false);
            tileToEnable.SetActive(true);
        }
    }
}
