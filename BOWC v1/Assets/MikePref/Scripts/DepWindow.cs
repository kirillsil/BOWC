using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepWindow : MonoBehaviour , IDepWindow
{
	public int index;
	public GameObject oPanel;
	public bool onoff; // show panel

	// Start is called before the first frame update
	void Start()
    {
		CityUI.s.AddDepWindow(this);

	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public int GetLevel()
	{
		return 0;
	}
	public int GetIndex()
	{
		return index;
	}

	public void Open()
	{
		oPanel.SetActive(true);
		onoff = true;
	}
	public void Close()
	{
		oPanel.SetActive(false);
		onoff = false;
	}

	public void Inverse()
	{
		if (!onoff)
			Open();
		else
			Close();
	}




}
