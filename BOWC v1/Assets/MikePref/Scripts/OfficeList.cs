using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfficeList : MonoBehaviour
{
	public GameObject[] oOffices;
	public Text [] unitNumber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnBtn()
	{
		gameObject.SetActive(!gameObject.activeSelf);
		if(gameObject.activeSelf) unitNumber[0].text=Player.s.GetUnitsNumber().ToString();
	}
}
