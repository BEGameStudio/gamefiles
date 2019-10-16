using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcidIngred : MonoBehaviour {
    public GameObject Acid;
    public GameObject jar;
    public float AcidAmmount;

	// Use this for initialization
	void Start () {

        jar = GameObject.FindWithTag("jar");
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}


     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "jar" && AcidAmmount >0)
        {
            AcidAmmount -= 10;
            Debug.Log("10 acid bosaldi");
            GameObject.FindWithTag("jar").GetComponent<JarIngred>().AcidAmmount +=10;
        }

        else
        {
            Debug.Log("Acid eklenemedi");
        }

        if(AcidAmmount == 0)
        {
            
        }


    }
}
