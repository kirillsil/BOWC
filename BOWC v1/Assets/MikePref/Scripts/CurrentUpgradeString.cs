using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentUpgradeString : MonoBehaviour
{
    public int state;

    public Text DepName;
    public Text depLevel;
    public Text timeTo;
    public Image iLamp;
    public GameObject oSpeedUpBtn;

    public int depIndex;
    public int level;
    public DepUpgrade du;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case 0:
                if(du.IsUgrading(level-1))
                {
                    state=1000;
                    iLamp.color=Color.white;
                    oSpeedUpBtn.SetActive(true);
                }
                break;
            case 1000:
                if(du.level>=level) Destroy(gameObject);
                else
                {
                    timeTo.text=GP.TimeString(du.GetTimeTo());
                }
                break;
        }
        
    }
    public void Init(int ind_,int level_,DepUpgrade du_)
    {
        depIndex=ind_;
        level=level_;
        du=du_;
        iLamp.color=new Color(0.3f,0.3f,0.3f);
        DepName.text=GP.depName[depIndex];
        depLevel.text="Level "+(level+1).ToString();
        timeTo.text=GP.TimeString(GP.upgrade[depIndex][5*level+2]);
    }

    public void OnSpeedUp()
    {
        du.OnCompleteUpgrade();
    }
}
