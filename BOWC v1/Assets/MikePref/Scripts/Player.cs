using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player s;// singleton
    public double money;
    public double moneyMax;
    public int gold;

    public string playerName;

    public int [] units;

    public int workplaceNumber;// количество раб мест в офисе

    public int [] depLevels; 
    // Start is called before the first frame update
    void Start()
    {
       //s = this;
        //money = GP.money;
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void Init()
    {
        s = this;
        money = GP.money;
    }

    public void AddMoney(double m_)
    {
        money += m_;
        if (money < 0) money = 0;
        if (CityUI.s != null && money > GP.upgrade[0][5*CityUI.s.depUpgrade[0].level+1])
            money = GP.upgrade[0][5*CityUI.s.depUpgrade[0].level+1];
    }
    public void AddGold(int g_)
    {
        gold+=g_;
    }

    public void AddUnit(int ind_, int num_)
    {
        units[ind_]+=num_;
    }
}
