using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingOnMouseEnter : MonoBehaviour
{
    // Start is called before the first frame update
    public Renderer rend;
    public Color col,colSel;
    void Start()
    {
        rend = GetComponent<Renderer>();
        //col = rend.material.color;
        rend.material.color = col;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseEnter()
    {
        rend.material.color = colSel;
    }
    void OnMouseExit()
    {
        rend.material.color = col;
    }
   void OnMouseOver()
    {
        rend.material.color = colSel;
        if (Input.GetMouseButtonDown(0)) CityUI.s.BuildingMenu(true);
    }

}
