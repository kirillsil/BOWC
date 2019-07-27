using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepSales : MonoBehaviour
{
    public Department department;
    public float addMoney;

    // Start is called before the first frame update
    void Start()
    {
        department = GetComponent<Department>();
    }

    // Update is called once per frame
    void Update()
    {
        addMoney = Time.deltaTime * GP.departAmount[1][department.level] / 3600;
        Player.s.AddMoney(addMoney);
        
    }
}
