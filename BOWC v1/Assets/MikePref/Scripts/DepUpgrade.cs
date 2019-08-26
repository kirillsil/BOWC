using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepUpgrade : MonoBehaviour, IBuyForGold, IDepWindow, ICloseWindow
{
    public int index;
    public int level;
    public float timUpgrade; // time from upgrade begin
    public int state; // 0 -  ? 1000- in upgrade
    public int upgrading; // 0-no, 1- doing 2 -max limit
    public int toComplete;// 0- no, 1 -half, 2-complete
   public bool onoff; // show panel
    public string sAmountName;

    public Text tLevel;
    public Text tCurMax;
 //   public Text tNextMax;
 //   public Text tFullTime;
 //   public Text tToMax;
    public Text tToTime;
 //   public Text tPrice;

    public float timeTo;
   public bool trig;
    public static int depInUpgrade=-1;//
    public static List<Vector2> queueToUpgrades=new List<Vector2>(); // x- index of dep., y- level

    //    public Text tCurTime;

    public Slider slTime;
    public Slider slTime2;

    public GameObject oPanel;

    public GameObject oDepUpString;
    public List <DepUpgradeString> duss;
    public GameObject oProgress;

	public BuyForGold orderForGold;
	public BuyForGold speedForGold;
	public int levelForQueue;

	// Start is called before the first frame update
	void Start()
    {
		CityUI.s.AddDepWindow(this);
        tLevel.text="Current level: "+(level+1).ToString();
        tCurMax.text=sAmountName+ GP.upgrade[index][5*level+1].ToString();
        InitStrings();
		orderForGold=CityUI.s.orderForGold;
		speedForGold=CityUI.s.speedForGold;

	}

	void Update()
    {
        switch (state)
        {
            case 0:
                if(depInUpgrade==-1)
                {
                    if(queueToUpgrades.Count>0 && queueToUpgrades[0].x==index)
                    {
                        state = 1000;
                        upgrading = 1;
                        timeTo = GP.upgrade[index][5 * (level + 1) + 3];
                        Refresh();
                        slTime2.gameObject.SetActive(true);
                        oProgress.SetActive(true);
                        //duss[0].ButtonOnOff(false);
                    }
                }

                        break;
            case 1000:
                timeTo -= Time.deltaTime;
                slTime2.value = (GP.upgrade[index][5*(level+1)+3] - timeTo) / GP.upgrade[index][5*(level+1)+3];
                if (timeTo<=0)
                {
                    slTime2.gameObject.SetActive(false);
                    oProgress.SetActive(false);
                    //GameObject _g=duss[0].gameObject;
                    //duss.RemoveAt(0);
                    //Destroy(_g);
                    level++;
                    CityUI.s.upgradeComplete(index,level);
                    //if(duss.Count>0 && Player.s.money>=GP.upgrade[index][5*(level+1)+2])
                    //    duss[0].ButtonOnOff(true);
 
                    state = 0;
                    toComplete=0;
                    if (level == GP.upgrade[index].Length-1)
                    {
                        upgrading = 2;
                       // oUpDoing.SetActive(false);
                       // oUpInfo.SetActive(false);
                       // oUpMax.SetActive(true);
                        
                    }
                    else upgrading = 0;
                    queueToUpgrades.RemoveAt(0);
                }
                if (onoff) Refresh();
                break;
        }
        //if(Input.GetMouseButtonDown(0))
        //{
        //    if(trig) ;//trig=false;
        //   // else Close();
        //}

    }

	//void OnMouseDown()
	//{
	//    if(onoff) trig=true;
	//}

	//public void OnPointDown()
	//{
	//    if(onoff) trig=true;
	//}

	public void StartUpgrade(int lev_)
	{
		if (GP.upgrade[index][5*(lev_)+2]<=Player.s.money)
		{
			int _n = queueToUpgrades.Count;
			if (_n<2)
			{
				Player.s.AddMoney(-GP.upgrade[index][5*(lev_)+2]);
				queueToUpgrades.Add(new Vector2(index,lev_));
				DepUpgradeString _dus = duss[0];
				duss.RemoveAt(0);
				CurrentUpgrade.s.NewString(index,lev_,this);
				Destroy(_dus.gameObject);
				if (duss.Count>0)
				{
					if (GP.upgrade[index][5*(duss[0].level)+2]<=Player.s.money)
						duss[0].ButtonOnOff(true);
				}
			}
			else
			{
				int _g = GP.goldForOrderOneMoreUpgrade*(_n-1);
				orderForGold.Order(this,_g);
				levelForQueue=lev_;
			}
		}
	}

    public void Show(bool onoff_)
    {
        if (onoff_) Open();
        else Close();
    }

    public void Open()
    {
        oPanel.SetActive(true);
        onoff = true;
		if (duss.Count>0)
		{
			duss[0].ButtonOnOff(GP.upgrade[index][5*(duss[0].level)+2]<=Player.s.money);
		}
		// CloseAnyWindow.s.AddMe(this);
		// if (onoff) Refresh();
	}
	public void Close()
    {
        oPanel.SetActive(false);
        onoff = false;
       // CloseAnyWindow.s.RemoveMe(this);
       // if (onoff) Refresh();
    }

    public void Inverse()
    {
       if (!onoff) Open();
        else Close();
    }

    public void CloseWindow()
    {
        Close();
    }
    void Refresh()
    {
        tLevel.text = "Current level: "+(level+1).ToString();
        tCurMax.text= sAmountName+GP.upgrade[index][5*(level)+1].ToString();
        if (upgrading==1)
        {
            //oUpDoing.SetActive(true);
            //oUpInfo.SetActive(false);
            //tToMax.text= GP.departAmount[index][level+1].ToString();
            tToTime.text = GP.TimeString(timeTo);
            slTime.value = (GP.upgrade[index][5*(level+1)+3] - timeTo) / GP.upgrade[index][5*(level+1)+3];
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

    public void OnCompleteUpgrade()
    {
		int _g50, _g100;
        if(state==1000)
        {
            if(toComplete==0)
            {
				_g50 = 5*(level+1);
				_g100= 10*(level+1);

				speedForGold.SpeedUp(this,_g50,_g100);

				if (Player.s.gold>=5*(level+1))
                {
                    Player.s.AddGold(-5*(level+1));
                    //(GP.upgrade[index][5*(level+1)+3] - timeTo)
                    timeTo-=0.5f*GP.upgrade[index][5*(level+1)+3];
                    toComplete=1;
                    return;
                }
            }
            if(toComplete==1)
            {
				_g50=-1;
				_g100= 5*(level+1);

				speedForGold.SpeedUp(this,_g50,_g100);

            }
        }
    }

    public bool IsUgrading(int lev_)
    {
        return lev_==level && state==1000;
    }
    public float GetTimeTo()
    {
        return timeTo;
    }
	public void OrderForGold()
	{
		Player.s.AddMoney(-GP.upgrade[index][5*(levelForQueue)+2]);
		queueToUpgrades.Add(new Vector2(index,levelForQueue));
		DepUpgradeString _dus = duss[0];
		duss.RemoveAt(0);
		CurrentUpgrade.s.NewString(index,levelForQueue,this);
		Destroy(_dus.gameObject);
		if (duss.Count>0)
		{
			if (GP.upgrade[index][5*(duss[0].level)+2]<=Player.s.money)
				duss[0].ButtonOnOff(true);
		}
	}

	public void Speed50ForGold()
	{
		timeTo-=0.5f*GP.upgrade[index][5*(level+1)+3];
		toComplete=1;
	}
	public void Speed100ForGold()
	{
		timeTo=0;
		toComplete=0;
	}

	public int GetLevel()
	{
		return level;
	}
	public int GetIndex()
	{
		return index;
	}
}

public interface ICloseWindow
{
	void CloseWindow();
}
public interface IDepWindow
{
	void Close();
	void Open();
	void Inverse();
	int GetLevel();
	int GetIndex();
}
