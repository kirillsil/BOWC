using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player s;// singleton
    public double money;
    public double moneyMax;
    // Start is called before the first frame update
    void Start()
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
        if (CityUI.s != null && money > GP.departAmount[0][CityUI.s.departments[0].level])
            money = GP.departAmount[0][CityUI.s.departments[0].level];
    }
}
