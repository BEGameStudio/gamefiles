using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canparavb : MonoBehaviour
{
    public float can, para;
    public GameObject map;
    public bool harita;


    // Start is called before the first frame update
    void Start()
    {
        can = 100;
        para = 1000;
        harita = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject textMoney = GameObject.Find("para");
        textMoney.GetComponent<Text>().text = "Money:" + para;


        GameObject textCan = GameObject.Find("can");
        textCan.GetComponent<Text>().text = "Health:" + can;


        if (Input.GetKeyDown(KeyCode.M))
        {
            
            if (!harita)
            {
                harita = true;
                map.SetActive(true);
            }

            else
            {
                harita = false;
                map.SetActive(false);
            }
        }  

    }
}
