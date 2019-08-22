using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepHumanBuy : MonoBehaviour, IBuyForGold
{
    public List <Vector2> orders;//x-index, y-amount
    public int unitInProgress=-1; // -1- finish; 
    public int speedUp; // 1-half time, 2 - 100%
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

    public BuyForGold orderForGold;
    public BuyForGold speedForGold;

    //public GameObject oGoldPayWin;
    //public GameObject oGoldPayWin50;
    //public Text tGold50;
    //public Text tGold100;

    //public Image iGold50;
    //public Image iGold100;

    // Start is called before the first frame update
    void Start()
    {
       // orderForGold=GameObject.Find("Window (Order Above)").GetComponent<BuyForGold>();
        //oGoldPayWin=GameObject.Find("Window (Order Above)");
       /// orderForGold=oGoldPayWin.GetComponent<BuyForGold>();
       orderForGold=CityUI.s.orderForGold;
       speedForGold=CityUI.s.speedForGold;
    }

    // Update is called once per frame
    void Update()
    {
        if(unitInProgress==-1)
            foreach(var _o in orders)
            {
                if(stateBuy[(int)_o[0]]==0)
                {
                    int _ind=(int)_o[0];
                    stateBuy[_ind]=1000;
                    unitNumBuy[_ind]=(int)_o[1];
                    timeTo[_ind]=GP.hire[_ind][1];
                    timeAllTo[_ind]=GP.hire[_ind][1]*unitNumBuy[_ind];
                    //orders.Remove(_o);
                    unitInProgress=_ind;
                    break;
                }
            }

        if(unitInProgress>=0) //for(int i=0;i<6;i++)
        {
            switch(stateBuy[unitInProgress])
            {
            case 1000:
                //if(unitNumBuy[i]>0)
                //{
                //    timeTo=GP.hire[i][1];
                timeTo[unitInProgress]-= Time.deltaTime;
                timeAllTo[unitInProgress]-= Time.deltaTime;
                if(timeTo[unitInProgress]<=0)
                {
                    Player.s.AddUnit(unitInProgress,1);
                    unitNumBuy[unitInProgress]--;
                    if(unitNumBuy[unitInProgress]>0)
                    {
                        timeTo[unitInProgress]=timeTo[unitInProgress]+GP.hire[unitInProgress][1];
                    }
                    else
                    {
                        timeTo[unitInProgress]= 0;
                        timeAllTo[unitInProgress]= 0;
                        stateBuy[unitInProgress]=0;
                            unitInProgress=-1;
                            orders.RemoveAt(0);
                            speedUp=0;
                    }
                }
                if(oLayerBuy.activeSelf && unitInProgress==unitIndex) RefreshBuy();
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

            //Player.s.AddUnit(unitIndex,unitNumBuy[unitIndex]);
            //unitNumBuy[unitIndex]=0;
            //timeTo[unitIndex]= 0;
            //timeAllTo[unitIndex]= 0;
            //stateBuy[unitIndex]=0;
            //RefreshBuy();
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
        if(slNum.value>0)    //  orders.Add(new Vector2(unitIndex,slNum.value));
        {
            if(orders.Count>1)
            {
                int _pay=(int)orders[0].y*GP.hireAbove2;
               orderForGold.Order(this,_pay);
               // oGoldPayWin.SetActive(true);
               // oGoldPayWin50.SetActive)false);
              //  int _pay=(int)orders[0].y*GP.hireAbove2;
               // tGold100.text=_pay.ToString();
               // if(_pay>Player.s.gold) iGold100.color=new Color(0.3f,0.3f,0.3f);
               // else iGold100.color=Color.white;
            }
            else
            {
                orders.Add(new Vector2(unitIndex,slNum.value));
                Player.s.AddMoney(-slNum.value*GP.hire[unitIndex][0]);
                RefreshBuy();
            }
        }
    }

    public void OrderForGold()
    {
        orders.Add(new Vector2(unitIndex,slNum.value));
        Player.s.AddMoney(-slNum.value*GP.hire[unitIndex][0]);
        RefreshBuy();
    }

    public void Speed50ForGold()
    {

    }
    public void Speed100ForGold()
    {
    }

    public int UnitsInOrder()
    {
        int _n=0;
        foreach(var _v in orders) _n+=(int)_v.y;
        return _n;
    }

}
