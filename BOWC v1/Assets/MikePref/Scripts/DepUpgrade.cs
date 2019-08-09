using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepUpgrade : MonoBehaviour
{
    public int index;
    public int level;
    public float timUpgrade; // time from upgrade begin
    public int state; // 0 -  ? 1000- in upgrade
    public int upgrading; // 0-no, 1- doing 2 -max limit

    public Text tLevel;
    public Text tCurMax;
    public Text tNextMax;
    public Text tFullTime;
    public Text tToMax;
    public Text tToTime;
    public Text tPrice;

    public float timeTo;

    //    public Text tCurTime;

    public Slider slTime;
    public Slider slTime2;

    public GameObject oPanel;

    public GameObject oDepUpString;
    public List <DepUpgradeString> duss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
