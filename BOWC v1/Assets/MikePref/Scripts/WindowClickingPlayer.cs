using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowClickingPlayer : MonoBehaviour , IBuyForGold
{
	public GameObject oMesBox;
	public Text tMesBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnBuyOffice()
	{
		int _gold = 1500*(1 +Player.s.officeNumber);
		CityUI.s.buyOfficeForGold.Order(this,_gold);


	}

	public void OrderForGold()
	{
		Player.s.AddNewOffice();
		oMesBox.SetActive(true);
		tMesBox.text="Поздравляем, количество ваших офисов стало равно " +  Player.s.officeNumber;
		gameObject.SetActive(false);
	}

	public void Speed50ForGold()
	{
	}
	public void Speed100ForGold()
	{
	}

	public void Close()
	{
		gameObject.SetActive(false);
	}

}
