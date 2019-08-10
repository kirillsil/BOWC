using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player s;// singleton
    public double money;
    public double moneyMax;
    // Start is called before the first frame update
    void Awake()
    {
        s = this;
        money = GP.money;
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void AddMoney(double m_)
    {
        money += m_;
        if (money < 0) money = 0;
        if (CityUI.s != null && money > GP.upgrade[0][5*CityUI.s.depUpgrade[0].level+1])
            money = GP.upgrade[0][5*CityUI.s.depUpgrade[0].level+1];
    }
}
