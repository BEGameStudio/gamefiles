using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillsIngred : MonoBehaviour
{
    public GameObject Pills;
    public GameObject jar;
    public float PillsAmmount;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "jar" && PillsAmmount > 0)
        {
            PillsAmmount -= 10;
            Debug.Log("10 hap bosaldi");
            GameObject.FindWithTag("jar").GetComponent<JarIngred>().PillsAmmount += 10;
        }

        else
        {
            Debug.Log("Haplar eklenemedi");
        }


    }
}
