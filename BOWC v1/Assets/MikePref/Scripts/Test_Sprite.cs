using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test_Sprite : MonoBehaviour
{
	public Sprite[] sp;
	public Image im;
	public int i;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnBtn(int i_)
	{
		i+=i_;
		if (i<0)
			i=0;
		if (i>5)
			i=5;
		im.sprite=sp[i];
		im.SetNativeSize();
	}

}
