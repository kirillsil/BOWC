using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityUI : MonoBehaviour
{
    public GameObject oCity;
    public GameObject oOfficeSelf;
    public GameObject oOfficeBackGround;
    public GameObject oBuildingMenu;
    public bool cityOn;
    public static CityUI s;

    public List<GameObject> oPanelDepartments;

    // Start is called before the first frame update
    void Start()
    {
        s = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickPanelDepartments(int n_)
    {
        if (oPanelDepartments[n_].activeSelf) oPanelDepartments[n_].SetActive(false);
        else
        {
            foreach (var _d in oPanelDepartments)
            {
                _d.SetActive(false);
                oPanelDepartments[n_].SetActive(true);
            }
        }
    }

    public void OnClickCityBtn()
    {
        if(cityOn)
        {
           // oCity.SetActive(false);
            oOfficeSelf.SetActive(true);
            oOfficeBackGround.SetActive(true);
            cityOn = false;
            return;
        }
        //else
        {
            //oCity.SetActive(true);
            oOfficeSelf.SetActive(false);
            oOfficeBackGround.SetActive(false);
            cityOn = true;
        }
    }

    public void BuildingMenu(bool en_)
    {
        oBuildingMenu.SetActive(en_);
    }
}
