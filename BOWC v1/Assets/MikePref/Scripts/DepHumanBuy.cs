using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepHumanBuy : MonoBehaviour
{
    public List <Vector2> orders;//x-index, y-amount
    public int [] stateBuy;//0-no, 1000 -buy
    public int [] unitNumBuy;//in progress
    public Text tTimeTo;
    public Text tPrice;
    public Text tTime;
    public Text tUnitName;
    public Slider slNum;
    public int unitIndex;
    public float [] timeTo;
    public float [] timeAllTo;

    public GameObject [] oPrevNextBtn;
   
    public GameObject oLayerBuy;
    public GameObject oGoldPayWin;
    public Text tGold;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var _o in orders)
        {
            if(stateBuy[(int)_o[0]]==0)
            {
                int _ind=(int)_o[0];
                stateBuy[_ind]=1000;
                unitNumBuy[_ind]=(int)_o[1];
                timeTo[_ind]=GP.hire[_ind][1];
                timeAllTo[_ind]=GP.hire[_ind][1]*unitNumBuy[_ind];
                orders.Remove(_o);
                break;
            }
        }

        for(int i=0;i<6;i++)
        {
            switch(stateBuy[i])
            {
            case 1000:
                //if(unitNumBuy[i]>0)
                //{
                //    timeTo=GP.hire[i][1];
                timeTo[i]-= Time.deltaTime;
                timeAllTo[i]-= Time.deltaTime;
                if(timeTo[i]<=0)
                {
                    Player.s.AddUnit(i,1);
                    unitNumBuy[i]--;
                    if(unitNumBuy[i]>0)
                    {
                        timeTo[i]=timeTo[i]+GP.hire[i][1];
                    }
                    else
                    {
                        timeTo[i]= 0;
                        timeAllTo[i]= 0;
                        stateBuy[i]=0;
                    }
                }
                if(oLayerBuy.activeSelf && i==unitIndex) RefreshBuy();
                break;
            }
        }
        
    }

    public void OpenBuy(int i_)
    {
        unitIndex=i_;
        RefreshBuy();
        oPrevNextBtn[0].SetActive(unitIndex>0);
        oPrevNextBtn[1].SetActive(unitIndex<5);
        
   }

    public void OnPrevNext( int i_)
    {
        unitIndex+=i_;
        OpenBuy(unitIndex);
    }
   public void OnBuyMax()
    {
        slNum.value=slNum.maxValue;
    }
   public void OnBuyImmed()
    {
        if(stateBuy[unitIndex]==1000)
        {
            Player.s.AddUnit(unitIndex,unitNumBuy[unitIndex]);
            unitNumBuy[unitIndex]=0;
            timeTo[unitIndex]= 0;
            timeAllTo[unitIndex]= 0;
            stateBuy[unitIndex]=0;
            RefreshBuy();
        }
    }

    void RefreshBuy()
    {
        if(timeAllTo[unitIndex]==0) tTimeTo.text="";
        else
            tTimeTo.text=GP.TimeString(timeAllTo[unitIndex]);
        tPrice.text=GP.hire[unitIndex][0].ToString();
        tTime.text=GP.TimeString(GP.hire[unitIndex][0]);
        tUnitName.text=GP.unitTypeName[unitIndex];
        int _n=Player.s.FreeWorkPlaces()-UnitsInOrder();
        int _n1=(int)Player.s.money/GP.hire[unitIndex][0];
        if(_n>_n1) _n=_n1;

        slNum.maxValue=_n;
    }

    public void OnBuy()
    {
        if(slNum.value>0) orders.Add(new Vector2(unitIndex,slNum.value));
        if(orders.Count>1)
        {
            oGoldPayWin.SetActive(true);

            tGold.text=((orders.Count-1)*GP.hireAbove2).ToString();
        }

        Player.s.AddMoney(-slNum.value*GP.hire[unitIndex][0]);
        RefreshBuy();
    }

    public int UnitsInOrder()
    {
        int _n=0;
        foreach(var _v in orders) _n+=(int)_v.y;
        return _n;
    }

}
