using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepUpgradeString : MonoBehaviour
{
    public Text tLevel;
    public Text tAmount;
    public Text tTime;
    public Text tPrice;
    public Image iButton;
    public DepUpgrade du;
    public bool buttonActive;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(int lev_,int am_,int tim_, int price_, bool onoff_, DepUpgrade du_)
    {
        tLevel.text=lev_.ToString();
        tAmount.text=am_.ToString();
        tTime.text=GP.TimeString(tim_);
        tPrice.text=price_.ToString();
        buttonActive=onoff_;
        if(onoff_) iButton.color=Color.white;
        else iButton.color=new Color(0.3f,0.3f,0.3f);
        du=du_;
    }

    public void OnUpgradeButton()
    {
        if(buttonActive) du.StartUpgrade();
    }
}
