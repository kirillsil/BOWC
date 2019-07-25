using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

	public int debI;
	public int debB;
	public int state;
	public float t,t1;

	string scene;
	public Text tLoad;

	public Animation dark;
	public GameObject darkPanel;

	public static int lang=1; //     язык 0-англ, 1 - русский
	public static bool touch; //управление от тача( да) или мыши (нет)
	//public static bool Exist; //синглтон
	public static string path;// путь для сохранений игры

	public int level=1; // текущий уровень игры 1-9
//	public int map=0; // текущая локация на карте
	public static GM s;



	void Awake () 
	{
		if(s==null)
		{
			s=this;
			DontDestroyOnLoad(gameObject);

			if(Application.systemLanguage.ToString()=="Russian")
			{
				lang=1;
				//	langD="Rus";
			}
			else
			{
				lang=0;
				//	langD="Eng";
			}

			touch=(Application.platform == RuntimePlatform.IPhonePlayer ||
				Application.platform == RuntimePlatform.Android);

			path=Application.persistentDataPath+"/";
		}
		else Destroy(gameObject);



	}

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		
	}

//	public void EndSc1_Start()
//	{
//		state=1100;
//		dark.Play();
//		t=Time.time+2;
//	}


	public void LoadScene(string name_)
	{
		state=2000;
		scene=name_;
	}
}
