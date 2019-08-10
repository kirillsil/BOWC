using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Закрыть какое либо окно при клике за его пределами.
public class CloseAnyWindow : MonoBehaviour
{
    public List<ICloseWindow> ICWs=new List<ICloseWindow>();
    public static CloseAnyWindow s;
    // Start is called before the first frame update
    void Awake()
    {
        s=this;
    }
    void Start()
    {
       gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddMe(ICloseWindow icw_)
    {
        ICWs.Add(icw_);
        gameObject.SetActive(true);
    }
    public void RemoveMe(ICloseWindow icw_)
    {
        ICWs.Remove(icw_);
        if(ICWs.Count<1) gameObject.SetActive(false);
    }

    public void OnClickMe()
    {
        //Debug.Log("count= "+ICWs.Count);
        while(ICWs.Count>0)
        {
            ICWs[0].CloseWindow();
        }
        ICWs.Clear();
        gameObject.SetActive(false);
    }


}
