using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotor : MonoBehaviour
{
    public float v;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,v*Time.deltaTime,0);
    }
}
