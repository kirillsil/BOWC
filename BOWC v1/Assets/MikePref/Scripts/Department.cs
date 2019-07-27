using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Department : MonoBehaviour
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
    public GameObject oUpInfo;
    public GameObject oUpDoing;
    public GameObject oUpMax;

    public bool onoff; // show panel
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
                        oUpDoing.SetActive(false);
                        oUpInfo.SetActive(false);
                        oUpMax.SetActive(true);
                        
                    }
                    else upgrading = 0;
                }
                if (onoff) Refresh();
                break;
        }

    }

    public void StartUpgrade()
    {
        if(GP.departPrice[index][level]<=Player.s.money)
        {
            Player.s.AddMoney(-GP.departPrice[index][level]);
           oUpInfo.SetActive(false);
           oUpDoing.SetActive(true);
            state = 1000;
            upgrading = 1;
            timeTo = GP.departTime[index][level];
            Refresh();
            slTime2.gameObject.SetActive(true);
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
            oUpDoing.SetActive(true);
            oUpInfo.SetActive(false);
            tToMax.text= GP.departAmount[index][level+1].ToString();
            tToTime.text = TimeString(timeTo);
            slTime.value = (GP.departTime[index][level] - timeTo) / GP.departTime[index][level];
            //slTime2.value = (GP.departTime[index][level] - timeTo) / GP.departTime[index][level];

        }
        else
        {
            if (upgrading == 0)
            {
                oUpDoing.SetActive(false);
                oUpInfo.SetActive(true);

                tNextMax.text = GP.departAmount[index][level + 1].ToString();
                tFullTime.text = GP.departTime[index][level + 1].ToString();
                tPrice.text = GP.departPrice[index][level].ToString();
            }
        }

        string TimeString(float tim_)
        {
            int _t = (int)tim_;
            int _d = _t / 86400;
            _t = _t % 86400;
            int _h = _t / 3600;
            _t = _t % 3600;
            int _m = _t / 60;
            _t = _t % 60;
            int _s = _t % 60;
            string _r="";
            if (_d > 0) _r = _d.ToString() + "дней";
            if (_h > 0) _r += _h.ToString() + "час.";

            if (_m > 0) _r += _m.ToString() + "мин.";
            _r += _s.ToString() + "сек.";
            return _r;

        }
        //    public Text tLevel;
        //public Text tCurMax;
        //public Text tNextMax;
        //public Text tFullTime;
    }


}


