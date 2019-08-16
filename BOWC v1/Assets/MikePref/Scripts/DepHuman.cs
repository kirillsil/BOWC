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
        for(int i=0;i<6;i++)
        {
            employed[i].text=Player.s.units[i].ToString()+" X "+GP.unitTypeName[i];
            available[i].text="Available: 0";//+Player.s.
        }
    }

    public void OnReturnToHire()
    {
       oMain.SetActive(false);
        oHire.SetActive(true);
        oLayerHuman.SetActive(true);
        oLayerBuy.SetActive(false);
        oLayerChar.SetActive(false);
 
    }
}
