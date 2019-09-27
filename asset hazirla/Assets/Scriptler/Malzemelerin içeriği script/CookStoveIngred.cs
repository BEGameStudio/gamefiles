using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookStoveIngred : MonoBehaviour {
    public float AcidAmmount,PillsAmmount,Methanol,puremeth,methsuyu,timer;
    public GameObject liquid;
    public GameObject smoke;

    private float dakika;
    private float saniye;



    // Use this for initialization
    void Start () {
        AcidAmmount = 0;
        PillsAmmount = 0;
        Methanol = 0;
        puremeth = 10;
        methsuyu = 0;
        timer = 300;
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "jar")
        {
            JarIngred jarkontrol = GameObject.FindWithTag("jar").GetComponent<JarIngred>();
            methsuyu += jarkontrol.methsuyu;
            jarkontrol.methsuyu -= jarkontrol.methsuyu;
            

            
            Debug.Log("cookstoveye meth suyu alindi");
            
        }

        else
        {
            Debug.Log("cookstoveye meth suyu alinamadi");
        }

        if (other.gameObject.tag == "borcam")
        {
            BorcamIngred borcamkontrol = GameObject.FindWithTag("borcam").GetComponent<BorcamIngred>();
            borcamkontrol.puremeth += puremeth;


            puremeth -= puremeth;
            
   


            Debug.Log("cook tubeden borcama puremeth alindi");

        }


    }
    void FixedUpdate()
    {

        ButtonScript kontrol = GameObject.FindWithTag("stovebutton").GetComponent<ButtonScript>();


        JarIngred jarkontrol = GameObject.FindWithTag("jar").GetComponent<JarIngred>();
        
        if (methsuyu == 20)
        {

            // TİMER OLAYINI YAPIYOSUN
            // TİMER OLAYINI YAPIYOSUN
            // TİMER OLAYINI YAPIYOSUN
            // TİMER OLAYINI YAPIYOSUN

            liquid.gameObject.SetActive(true);

            if (kontrol.buttonacik == true)
            {
                smoke.gameObject.SetActive(true);
                dakika = Mathf.Floor(timer / 60);
                saniye = Mathf.Floor(timer % 60);


                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    kontrol.buttonacik = false;
                    timer = 300;
                    methsuyu -= 20;
                    puremeth += 10;
                }
            }

            if(kontrol.buttonacik ==false) { smoke.gameObject.SetActive(false); }
        }


        else
        {
            liquid.gameObject.SetActive(false);

            if (puremeth == 10)
            {
                liquid.gameObject.SetActive(true);
            }

            else { liquid.gameObject.SetActive(false); }
        }





        GameObject liquidText = GameObject.Find("MethLiquid");
        liquidText.GetComponent<Text>().text = "Meth:" + puremeth;

        GameObject TubeCookIngredText = GameObject.Find("TubeCookIngredText");
        TubeCookIngredText.GetComponent<Text>().text = "Ingredit:" + methsuyu;

        GameObject TubeTimer = GameObject.Find("CookTubeTimer");
        TubeTimer.GetComponent<Text>().text = "Timer:" + dakika +":"+ saniye;

    }
}
