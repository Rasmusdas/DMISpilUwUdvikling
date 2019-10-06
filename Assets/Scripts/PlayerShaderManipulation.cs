using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShaderManipulation : MonoBehaviour
{
    public static MeshRenderer mR;
    public static SpriteRenderer sR;
    public static int amountOfTimesTilNoPulse = 25;
    private void Start()
    {
        if (TryGetComponent(out SpriteRenderer _))
        {
            sR = GetComponent<SpriteRenderer>();
        }

        if (TryGetComponent(out MeshRenderer _))
        {
            mR = GetComponent<MeshRenderer>();
        }
        UpdateShader();
    }
    public static void UpdateShader()
    {
        float _ = 1-(float)GameManager.timesDied / (float)amountOfTimesTilNoPulse;
        print(_);
        if(_ < 0)
        {
            _ = 0;
        }
        if(mR)
        {
            mR.sharedMaterial.SetVector("_PulseMinMax", new Vector4(_ / 2, _, 0, 0));
        }
        if(sR)
        {
            sR.sharedMaterial.SetFloat("_DistAmount", GameManager.timesDied * 2 / (float)amountOfTimesTilNoPulse);
        }
    }
}
