using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class market : MonoBehaviour
{
    public float alisveristutar,alincakacid,spawnolcakacid,alincakpills,spawnolcakpills;
    public GameObject poset;



    // Start is called before the first frame update
    void Start()
    {
        spawnolcakacid = 0;
        alisveristutar = 0;
        alincakacid = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        GameObject textKasa = GameObject.Find("HesapTutar");
        textKasa.GetComponent<Text>().text = alisveristutar+"$";




    }
}
