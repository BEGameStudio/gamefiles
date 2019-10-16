using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poset : MonoBehaviour
{

    
    public GameObject acid,pills,bag;
    public float spawnlancakacid, spawnlancakpills;
    public bool acildi = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        market marketsatinalma = GameObject.FindWithTag("market").GetComponent<market>();
        bag = GameObject.FindWithTag("poset");

        spawnlancakacid = marketsatinalma.spawnolcakacid;
        spawnlancakpills = marketsatinalma.spawnolcakpills;

        if (acildi)
        {




            for (int x = 0; x < spawnlancakacid; x++)

            {
                 Instantiate(acid, bag.transform.position, Quaternion.identity);


            }

            for (int x = 0; x < spawnlancakpills; x++)

            {
                Instantiate(pills, bag.transform.position, Quaternion.identity);

            }

            marketsatinalma.spawnolcakacid = 0;
            marketsatinalma.spawnolcakpills = 0;

            GameObject.Destroy(bag);



        }



    }
}
