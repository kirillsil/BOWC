using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepHuman : MonoBehaviour
{
    public DepUpgrade DU;
    public DepHumanBuy DHB;
    public DepHumanChar DHC;
    public int onActive; // 0,1

    public GameObject oLayerHuman;
    public GameObject oMain;
 
    public GameObject oHire;
    public Text [] employed;
    public Text [] available;

    public GameObject oLayerBuy;

    public GameObject oLayerChar;
 


    // Start is called before the first frame update
    void Start()
    {
        DU=GetComponent<DepUpgrade>();
        DHB=GetComponent<DepHumanBuy>();
        DHC=GetComponent<DepHumanChar>();
}

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        if(onActive==0 && DU.onoff)
        {
            onActive=1;
            OnButtonMain();
            oLayerChar.SetActive(false);
            oLayerBuy.SetActive(false);
        }
        else
        {
            if(!DU.onoff)
            {
                onActive=0;
             oLayerHuman.SetActive(false);
            oLayerBuy.SetActive(false);
            oLayerChar.SetActive(false);
               }
        }
    }

    public void OnButtonHire()
    {
        oMain.SetActive(false);
        oHire.SetActive(true);
        RefreshHire();
    }
    public void OnButtonMain()
    {
        oMain.SetActive(true);
        oHire.SetActive(false);
    }

    public void OnButtonBuy(int i)
    {
        oMain.SetActive(true);
        oHire.SetActive(false);
        oLayerHuman.SetActive(false);
        oLayerBuy.SetActive(true);
        oLayerChar.SetActive(false);
        DHB.OpenBuy(i);
     }
    public void OnButtonChar(int i)
    {
        oMain.SetActive(true);
        oHire.SetActive(false);
        oLayerHuman.SetActive(false);
        oLayerBuy.SetActive(false);
        oLayerChar.SetActive(true);
        DHC.OpenChar(i);
        }


    void RefreshHire()
    {
        int _n,_n1;
        for(int i=0;i<6;i++)
        {
            employed[i].text=Player.s.units[i].ToString()+" X "+GP.unitTypeName[i];
            _n=Player.s.FreeWorkPlaces()-DHB.UnitsInOrder();
            _n1=(int)Player.s.money/GP.hire[i][0];
            if(_n>_n1) _n=_n1;
            available[i].text="Available: "+_n.ToString();
        }
    }

    public void OnReturnToHire()
    {
       oMain.SetActive(false);
        oHire.SetActive(true);
        oLayerHuman.SetActive(true);
        oLayerBuy.SetActive(false);
        oLayerChar.SetActive(false);
        RefreshHire();
 
    }
}
