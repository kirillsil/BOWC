using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepHumanChar : MonoBehaviour
{
    public int ind;
    public Text tUnitName;
    public Text tUnitDesc;
    public Text [] tParam;
    public GameObject [] oPrevNextBtn;
    public Image iUnit;

    public Sprite [] spUnits;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenChar(int i_)
    {
        ind=i_;
        tUnitName.text=GP.unitTypeName[i_];
        tUnitDesc.text=GP.unitTypeDesc[i_];
        iUnit.sprite=spUnits[ind];
        for(int i=0;i<6;i++)
        {
            tParam[i].text=GP.unitAttackDefend[i_][i].ToString();
        }
         oPrevNextBtn[0].SetActive(ind>0);
        oPrevNextBtn[1].SetActive(ind<5);

   }

    public void OnPrevNext( int i_)
    {
        ind+=i_;
        OpenChar(ind);
    }


}
