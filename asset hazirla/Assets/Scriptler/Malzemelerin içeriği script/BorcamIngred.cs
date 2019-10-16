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
    void FixedUpdate()
    {
        
    }


	void OnTriggerEnter(Collider other)
	{

		
        

        if (puremeth == 10)
		{
			meth.gameObject.SetActive(true);

          
			
			Debug.Log("puremeth geldi");
		}
		
		

        

        if (other.gameObject.tag == "hammer" && puremeth == 10)
        {
            

            
            puremeth -= 10;
            Debug.Log("kirildi");

            meth.gameObject.SetActive(false);


            Instantiate(methpack, borcam.transform.position, Quaternion.identity);
        } 
        

    }
    
}
