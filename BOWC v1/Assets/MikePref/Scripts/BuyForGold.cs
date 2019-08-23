using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyForGold : MonoBehaviour
{
    public int gold50;
    public int gold100;

    IBuyForGold ibg;

    public Text tGold50;
    public Text tGold100;

    public Image iGold50;
    public Image iGold100;

    bool order; // order or speed up
    bool enough50;
    bool enough100;

    // Start is called before the first frame update
     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Order(IBuyForGold ibg_, int gold_)
    {
        order=true;
        gameObject.SetActive(true);
        ibg=ibg_;
        gold50=gold_;
        tGold50.text=gold_.ToString();
        enough50=gold_<=Player.s.gold;
        if(!enough50) iGold50.color=new Color(0.3f,0.3f,0.3f);
        else iGold50.color=Color.white;
    }

    public void SpeedUp(IBuyForGold ibg_, int gold50_, int gold100_)
    {
        order=false;
        gameObject.SetActive(true);
        ibg=ibg_;
        if(gold50_<0)
        {
            tGold50.text="0";
            iGold50.color=new Color(0.3f,0.3f,0.3f);
            enough50=false;
        }
        else
        {
            tGold50.text=gold50_.ToString();
            enough50=gold50_<=Player.s.gold;
            if(!enough50) iGold50.color=new Color(0.3f,0.3f,0.3f);
            else iGold50.color=Color.white;
        }
        tGold100.text=gold100_.ToString();
        enough100=gold100_<=Player.s.gold;
        if(!enough100) iGold100.color=new Color(0.3f,0.3f,0.3f);
        else iGold100.color=Color.white;
    }

    public void OnClose()
    {
        gameObject.SetActive(false);
    }
    public void OnBtnBuy50()
    {
        if(enough50)
        {
            if(order)
            {
                ibg.OrderForGold();
            }
            else
            {
                ibg.Speed50ForGold();
            }
            Player.s.AddGold(-gold50);
         gameObject.SetActive(false);
       }
    }
    public void OnBtnBuy100()
    {
        if(enough100)
        {
            ibg.Speed100ForGold();
            Player.s.AddGold(-gold100);
             gameObject.SetActive(false);
        }
    }

}

public interface IBuyForGold
{
    void OrderForGold();
    void Speed50ForGold();
    void Speed100ForGold();
}

