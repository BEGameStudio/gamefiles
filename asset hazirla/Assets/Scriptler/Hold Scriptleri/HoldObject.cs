﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HoldObject : MonoBehaviour
{
    public Transform player;
    public Transform Kamera;
    public Transform Seat;
    public GameObject Unseat;
    public GameObject tekdondur;
    public Transform araba;
    private Camera playerCam;
    public float throwForce = 10;
    public bool beingCarried = false;
    public bool aracsur = false;
    public AudioClip[] soundToPlay;
    public float mesafe;
    private Ray playerAim;
    public float smooth;
   

    
    

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        




        playerCam = Camera.main;
        Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(playerAim, out hit, mesafe))
        {


            if (Input.GetMouseButton(0) && hit.collider.gameObject.tag != "tasinamayan" && beingCarried == false) // TERRAİNİ TAŞIYON DÜZELT
            {
                

                 tekdondur = hit.collider.gameObject;  // OBJELERİ AYRI AYRI TUTMA KODU


                tekdondur.GetComponent<Rigidbody>().isKinematic = true;
                tekdondur.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                tekdondur.transform.parent = Kamera; //AYRI TUTMA KODUNA BUDA DAHİL
                                                     //tekdondur.transform.SetParent(Kamera);

                beingCarried = true;


            }


            if (Input.GetKeyDown(KeyCode.F) && hit.collider.transform == araba && aracsur ==false) 
            {


                Debug.Log("oldu");

                aracsur = true;
                player.transform.parent = Seat;
                player.transform.position = Seat.transform.position;

                 player.GetComponent<Rigidbody>().isKinematic = true;
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                
                araba.GetComponent<Dot_Truck_Controller>().enabled = true;
            }
        }

        if(aracsur)
        {
            

            if (Input.GetKeyDown(KeyCode.G))
            {
                araba.GetComponent<Dot_Truck_Controller>().enabled = false;
                aracsur = false;
                player.transform.parent = null;
               player.transform.position = Unseat.transform.position;
                player.GetComponent<Rigidbody>().isKinematic = false;
                player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            }


        }

        if(araba.GetComponent<Dot_Truck_Controller>().enabled == false)
        {
            araba.GetComponent<Rigidbody>().isKinematic = true;
            araba.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        }

        if (araba.GetComponent<Dot_Truck_Controller>().enabled == true)
        {
            araba.GetComponent<Rigidbody>().isKinematic = false;
            araba.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }




        if (beingCarried)
            {



             //tekdondur = Kamera.transform.GetChild(0).gameObject;  //TEK DÖNDÜRMEYE KODU - GETCHİLD HATASI VEREN KOD

            if(tekdondur == null)
            {
                beingCarried = false;
            }



            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                {
                    tekdondur.transform.Rotate(Camera.main.transform.right, smooth * Time.deltaTime, Space.World);

                
            }
                if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                {
                
                tekdondur.transform.Rotate(-Camera.main.transform.right, smooth * Time.deltaTime, Space.World);
                    //kameranın baktığı yönde döndürme tekdondur. olmadanki hali
                }

            if (Input.GetMouseButton(1))
            {

               

                beingCarried = false;

                tekdondur.GetComponent<Rigidbody>().isKinematic = false;
                tekdondur.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                tekdondur.transform.parent = null;

                tekdondur = null;
            }
            

        }

        






        //if (Input.GetMouseButtonDown(0))
        //{
        //  GetComponent<Rigidbody>().isKinematic = false;
        //transform.parent = null;
        //beingCarried = false;
        //GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
        //}





    }
}