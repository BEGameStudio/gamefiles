using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class methpack : MonoBehaviour
{

    public float puremeth;
    public GameObject tuco1,paket,yazi;

    // Start is called before the first frame update
    void Start()
    {
        puremeth = 10;

        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {

        canparavb ticaret = GameObject.FindWithTag("Player").GetComponent<canparavb>();
        HoldObject kayipobje = GameObject.FindWithTag("Player").GetComponent<HoldObject>();

        if (other.gameObject.tag == "tuco1")
        {
            ticaret.para += 1000;
            Destroy(paket);
            yazi.SetActive(true);
            kayipobje.tekdondur = null;
        }
    }
}
