using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepSales : MonoBehaviour
{
    public DepUpgrade du;
    public float addMoney;

    // Start is called before the first frame update
    void Start()
    {
        du = GetComponent<DepUpgrade>();
    }

    // Update is called once per frame
    void Update()
    {
        addMoney = Time.deltaTime * GP.upgrade[1][5*du.level+1] / 3600;
        Player.s.AddMoney(addMoney);
        
    }
}
