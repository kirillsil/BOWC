using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentUpgrade : MonoBehaviour
{
    public GameObject oCurUpString;
    public Transform trContent;
    public static CurrentUpgrade s;
    // Start is called before the first frame update
    void Awake()
    {
        s=this;
    }
   void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewString(int ind_,int level_, DepUpgrade du_)
    {
        //oCurUpString.SetActive(true);
        GameObject _g=Instantiate(oCurUpString) as GameObject;
        _g.SetActive(true);
            _g.transform.SetParent(trContent,false);
            _g.GetComponent<CurrentUpgradeString>().Init(ind_,level_,du_);
         
        //oCurUpString.SetActive(false);
    }

}
