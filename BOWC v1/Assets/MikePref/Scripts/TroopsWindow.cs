using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TroopsWindow : MonoBehaviour
{
	public Text[] tNumber;
	public static TroopsWindow s;

	// Start is called before the first frame update
	void Awake ()
	{
		s=this;
	}
	void Start()
	{
		Refresh();
	}

	// Update is called once per frame
	void Update()
    {
        
    }

	public void Refresh()
	{
		for (int i=0;i<6;i++)
		{
			tNumber[i].text=Player.s.units[i].ToString();
		}
	}


}
