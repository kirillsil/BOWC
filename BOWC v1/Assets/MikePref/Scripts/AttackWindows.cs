using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWindows : MonoBehaviour
{
    public GameObject oClickPlayer;
    public GameObject oAttackPlayer;
    public GameObject oSupportTroops;
    public GameObject oSupportResources;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenClickPlayer()
    {
        oClickPlayer.SetActive(true);
        oAttackPlayer.SetActive(false);
        oSupportTroops.SetActive(false);
        oSupportResources.SetActive(false);
    }

    public void OpenAttackPlayer()
    {
        oClickPlayer.SetActive(false);
        oAttackPlayer.SetActive(true);
        oSupportTroops.SetActive(false);
        oSupportResources.SetActive(false);
    }
    public void OpenSupportTroops()
    {
        oClickPlayer.SetActive(false);
        oAttackPlayer.SetActive(false);
        oSupportTroops.SetActive(true);
        oSupportResources.SetActive(false);
    }
    public void OpenSupportResources()
    {
        oClickPlayer.SetActive(false);
        oAttackPlayer.SetActive(false);
        oSupportTroops.SetActive(false);
        oSupportResources.SetActive(true);
    }

    public void CloseAll()
    {
        oClickPlayer.SetActive(false);
        oAttackPlayer.SetActive(false);
        oSupportTroops.SetActive(false);
        oSupportResources.SetActive(false);
    }

}
