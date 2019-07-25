using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public float debI;
    public Camera miniMapCam;
    public bool scale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        debI += Input.mouseScrollDelta.y;
        if (scale && Input.mouseScrollDelta.y != 0) miniMapCam.orthographicSize *= 1 - 0.1f * Input.mouseScrollDelta.y;
    }

    public void OnMouseOver()
    {
        if (Input.mouseScrollDelta.y != 0) miniMapCam.orthographicSize *= 1 - 0.1f * Input.mouseScrollDelta.y;
    }

    public void Scaling(bool s_)
    {
        scale = s_;
    }
}
