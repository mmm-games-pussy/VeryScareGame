using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : MonoBehaviour
{
    public Light light;
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if(light.enabled==true)
        {
         mat.EnableKeyword("_EMISSION");
         mat.SetColor("_Color", Color.yellow);
        }
        else
        {
         mat.DisableKeyword("_EMISSION");
         mat.SetColor("_Color", Color.white);
        }
    }
}
