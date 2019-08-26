using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityUI:MonoBehaviour
{
	public Text tMoney;
	public Text tGold;
	public Text tPlayerName;

	public GameObject oCity;
	public GameObject oOfficeSelf;
	public GameObject oOfficeBackGround;
	public GameObject oBuildingMenu;
	public AttackWindows attackWindows;
	public bool cityOn;

	public BuyForGold orderForGold;
	public BuyForGold speedForGold;



	public static CityUI s;


	//public List<GameObject> oPanelDepartments;
	public IDepWindow [] depUpgrade= new IDepWindow[9];

	// Start is called before the first frame update

	private void Awake()
	{
		s = this;
	}
	void Start()
	{

		tMoney.text = ((int)Player.s.money).ToString("### ### ### ###");
		tPlayerName.text = Player.s.playerName;
	}

	// Update is called once per frame
	void Update()
	{
		tMoney.text = ((int)Player.s.money).ToString("### ### ### ###");
		tGold.text=Player.s.gold.ToString();
	}

	public void OnClickPanelDepartments(int n_)
	{
		for (int i = 0;i < depUpgrade.Length;i++)
		{
			if (depUpgrade[i]!=null)
			{
				if (i != n_)
					depUpgrade[i].Close();
				else
					depUpgrade[i].Inverse();
			}
		}
		//if (oPanelDepartments[n_].activeSelf) oPanelDepartments[n_].SetActive(false);
		//else
		//{
		//    foreach (var _d in oPanelDepartments)
		//    {
		//        _d.SetActive(false);
		//        oPanelDepartments[n_].SetActive(true);
		//    }
		//}
	}

	public void OnClickCityBtn()
	{
		if (cityOn)
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
		//oBuildingMenu.SetActive(en_);
		attackWindows.OpenClickPlayer();
	}

	public void upgradeComplete(int depIndex,int level_)
	{
	}

	public void AddDepWindow(IDepWindow w_)
	{
		depUpgrade[w_.GetIndex()]=w_;
	}
}
