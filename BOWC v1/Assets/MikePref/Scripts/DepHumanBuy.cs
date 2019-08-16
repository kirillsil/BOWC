using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepHumanBuy : MonoBehaviour
{
    public List <Vector2> orders;//x-index, y-amount
    public int [] stateBuy;//0-no, 1000 -buy
    public Text tTimeTo;
    public Text tPrice;
    public Text tTime;
    public Text tUnitName;
    public Slider number;
    public int unitIndex;
    public float [] timeTo;
    public float [] timeAllTo;

    
    public GameObject oLayerBuy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenBuy(int i_)
    {

    }

    void RefreshBuy()
    {
        tTimeTo.text=GP.TimeString(timeAllTo[unitIndex]);
        tPrice.text=GP.hire[unitIndex][0].ToString();
        tTime.text=GP.TimeString(GP.hire[unitIndex][0]);
        tUnitName.text=GP.unitTypeName[unitIndex];

    }


}
