using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HoldPills : MonoBehaviour
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

            if (Input.GetMouseButtonDown(0) && hit.collider.gameObject)
            {

                GameObject tekdondur = hit.collider.gameObject;  // OBJELERİ AYRI AYRI TUTMA KODU

                GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
                tekdondur.transform.parent = Kamera; //AYRI TUTMA KODUNA BUDA DAHİL

                beingCarried = true;
            }
        }


        if (beingCarried)
        {

            GameObject tekdondur = Kamera.transform.GetChild(0).gameObject;  //TEK DÖNDÜRMEYE KODU



            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                tekdondur.transform.Rotate(Camera.main.transform.right, smooth * Time.deltaTime, Space.World);
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {

                tekdondur.transform.Rotate(-Camera.main.transform.right, smooth * Time.deltaTime, Space.World);
                //kameranın baktığı yönde döndürme tekdondur. olmadanki hali
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