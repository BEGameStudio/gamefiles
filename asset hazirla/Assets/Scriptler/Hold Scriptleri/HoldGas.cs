using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HoldGas : MonoBehaviour
{
    public Transform player;
    public Transform Kamera;
    public Transform Obje;
    private Camera playerCam;
    public float throwForce = 10;
    bool beingCarried = false;
    public AudioClip[] soundToPlay;
    public float mesafe;
    private Ray playerAim;
    public float smooth;




    void Start()
    {
    }

    void Update()
    {


        playerCam = Camera.main;
        Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(playerAim, out hit, mesafe))
        {

            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject.tag == "gas")
            {



                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                transform.parent = Kamera;

                beingCarried = true;
            }
        }

        if (beingCarried)
        {




            if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward  //obje döndüğünde raycast collidere çarpmadığında obje dönmüyor düzelt
            {
                transform.Rotate(Camera.main.transform.right, smooth * Time.deltaTime, Space.World);
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f) // geri
            {
                transform.Rotate(-Camera.main.transform.right, smooth * Time.deltaTime, Space.World);
                //kameranın baktığı yönde döndürme
            }


            //if (Input.GetMouseButtonDown(0))
            //{
            //  GetComponent<Rigidbody>().isKinematic = false;
            //transform.parent = null;
            //beingCarried = false;
            //GetComponent<Rigidbody>().AddForce(playerCam.forward * throwForce);
            //}

            if (Input.GetMouseButtonDown(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                transform.parent = null;
                beingCarried = false;
            }
        }




    }
}