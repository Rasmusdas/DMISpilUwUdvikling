using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShaderManipulation : MonoBehaviour
{
    public MeshRenderer mR;
    public int amountOfTimesTilNoPulse;
    private void Start()
    {
        mR = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        float _ = 1-(float)GameManager.timesDied / (float)amountOfTimesTilNoPulse;
        print(_);
        if(_ < 0)
        {
            _ = 0;
        }
        mR.sharedMaterial.SetVector("_PulseMinMax", new Vector4(0,_, 0,0));
    }
}
