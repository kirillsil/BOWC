using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sc_CharSelect : MonoBehaviour
{
    public InputField inName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCreate()
    {
        Player.s.playerName=inName.text;
        SceneManager.LoadScene("mcp_day");
    }
}
