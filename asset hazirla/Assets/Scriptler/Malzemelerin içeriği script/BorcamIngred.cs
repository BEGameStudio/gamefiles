using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorcamIngred : MonoBehaviour
{
	public float puremeth;
	public GameObject meth, borcam, methpack,hammer;
     
    canparavb CP;
    // Start is called before the first frame update
    void Start()
    {

        puremeth = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


	void OnTriggerEnter(Collider other)
	{

		CookStoveIngred methkontrol = GameObject.FindWithTag ("stovetube").GetComponent<CookStoveIngred>();
        

        if (other.gameObject.tag == "stovetube" && methkontrol.puremeth == 10)
		{
			meth.gameObject.SetActive(true);
            puremeth += methkontrol.puremeth;

            methkontrol.puremeth -= methkontrol.puremeth;
			
			Debug.Log("puremeth geldi");
		}
		
		else
		{
			meth.gameObject.SetActive(false);
			Debug.Log("puremeth  gelmedi");
		}

        

        if (other.gameObject == hammer && puremeth == 10)
        {
            

            
            puremeth -= 10;
            Debug.Log("kirildi");
            
            
            

            Instantiate(methpack, borcam.transform.position, Quaternion.identity);
        } 
        

    }
    
}
