using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JarIngred : MonoBehaviour {
    public float AcidAmmount;
    public float PillsAmmount;
    public float Methanol;
    public float puremeth;
    public float methsuyu;
    public GameObject sivi;
    public GameObject sivi2;
	// Use this for initialization
	void Start () {
     AcidAmmount = 0;
     PillsAmmount = 0;
     Methanol = 0;
     puremeth = 0;
     methsuyu = 0;
}
	
	// Update is called once per frame
	void Update () {
        if(AcidAmmount > 59 && PillsAmmount >39)
        {
            methsuyu += 20;
            
            AcidAmmount = 0;
            PillsAmmount = 0;
        }
        if(methsuyu > 9)
        {
            sivi.gameObject.SetActive(true);
        }

        
        if (methsuyu == 0)
        {
            sivi.gameObject.SetActive(false);
      
        }

    }

  /*  void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "stovetube" && methsuyu > 0)
        {
            
            Debug.Log("jardan meth suyu bosaldi");
           CookStoveIngred kontrol = GameObject.FindWithTag("stovetube").GetComponent<CookStoveIngred>();
            kontrol.methsuyu += methsuyu;
        }

        else
        {
            Debug.Log("jardan meth suyu eklenemedi");
        }


    } */

    void FixedUpdate()
    {
        GameObject textAcid = GameObject.Find("AcidText");
        textAcid.GetComponent<Text>().text = "Acid:" + AcidAmmount;


        GameObject textPills = GameObject.Find("PillsText");
        textPills.GetComponent<Text>().text = "Pills:" + PillsAmmount;

        GameObject CookIngredText = GameObject.Find("CookIngredText");
        CookIngredText.GetComponent<Text>().text = "Ingredit:" + methsuyu;

    }
}
