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
   public bool onoff; // show panel

    public Text tLevel;
    public Text tCurMax;
 //   public Text tNextMax;
 //   public Text tFullTime;
 //   public Text tToMax;
    public Text tToTime;
 //   public Text tPrice;

    public float timeTo;

    //    public Text tCurTime;

    public Slider slTime;
    public Slider slTime2;

    public GameObject oPanel;

    public GameObject oDepUpString;
    public List <DepUpgradeString> duss;
    public GameObject oProgress;

    // Start is called before the first frame update
    void Start()
    {
        tLevel.text="Current level: "+(level+1).ToString();
        tCurMax.text="Capacity: "+ GP.upgrade[index][5*level+1].ToString();
        InitStrings();
        
    }

    void Update()
    {
        switch (state)
        {
            case 0:
                break;
            case 1000:
                timeTo -= Time.deltaTime;
                slTime2.value = (GP.departTime[index][level] - timeTo) / GP.departTime[index][level];
                if (timeTo<=0)
                {
                    slTime2.gameObject.SetActive(false);
                    level++;
                    state = 0;
                    if (level == GP.departAmount[index].Length - 1)
                    {
                        upgrading = 2;
                       // oUpDoing.SetActive(false);
                       // oUpInfo.SetActive(false);
                       // oUpMax.SetActive(true);
                        
                    }
                    else upgrading = 0;
                }
                if (onoff) Refresh();
                break;
        }

    }

    public void StartUpgrade()
    {
        if(GP.upgrade[index][5*(level+1)+2]<=Player.s.money)
        {
            Player.s.AddMoney(-GP.departPrice[index][level]);
           //oUpInfo.SetActive(false);
           //oUpDoing.SetActive(true);
            state = 1000;
            upgrading = 1;
            timeTo = GP.departTime[index][level];
            Refresh();
            slTime2.gameObject.SetActive(true);
            oProgress.SetActive(true);
            GameObject _g=duss[0].gameObject;
            duss.RemoveAt(0);
            Destroy(_g);
        }
 
    }

    public void Show(bool onoff_)
    {
        oPanel.SetActive(onoff_);
        onoff = onoff_;
        if (onoff) Refresh();
    }

    public void Close()
    {
        oPanel.SetActive(false);
        onoff = false;
       // if (onoff) Refresh();
    }

    public void Inverse()
    {
        onoff = !onoff;
        oPanel.SetActive(onoff);
        if (onoff) Refresh();
    }

    void Refresh()
    {
        tLevel.text = (level+1).ToString();
        tCurMax.text= GP.departAmount[index][level].ToString();
        if (upgrading==1)
        {
            //oUpDoing.SetActive(true);
            //oUpInfo.SetActive(false);
            //tToMax.text= GP.departAmount[index][level+1].ToString();
            tToTime.text = GP.TimeString(timeTo);
            slTime.value = (GP.departTime[index][level] - timeTo) / GP.departTime[index][level];
            //slTime2.value = (GP.departTime[index][level] - timeTo) / GP.departTime[index][level];

        }
        else
        {
            if (upgrading == 0)
            {
                //oUpDoing.SetActive(false);
                //oUpInfo.SetActive(true);

               // tNextMax.text = GP.departAmount[index][level + 1].ToString();
                //tFullTime.text = GP.departTime[index][level + 1].ToString();
                //tPrice.text = GP.departPrice[index][level].ToString();
            }
        }

        //    public Text tLevel;
        //public Text tCurMax;
        //public Text tNextMax;
        //public Text tFullTime;
    }
    public void InitStrings()
    {
        GameObject _g;
        DepUpgradeString _dus;
        int _l=GP.upgrade[index].Length/5;
        for(int i=level+1; i<_l; i++)
        {
            _g=Instantiate(oDepUpString) as GameObject;
            _g.transform.SetParent(oDepUpString.transform.parent,false);
            _dus=_g.GetComponent<DepUpgradeString>();
            duss.Add(_dus);
            if(i==level+1 && Player.s.money>=GP.upgrade[index][5*(level+1)+2])
                _dus.Init(GP.upgrade[index][5*i],GP.upgrade[index][5*i+1],GP.upgrade[index][5*i+3],GP.upgrade[index][5*i+2],true,this);
            else
                _dus.Init(GP.upgrade[index][5*i],GP.upgrade[index][5*i+1],GP.upgrade[index][5*i+3],GP.upgrade[index][5*i+2],false,this);
        }
        oDepUpString.SetActive(false);
    }
}
