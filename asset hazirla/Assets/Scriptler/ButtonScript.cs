using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonScript : MonoBehaviour
{
    public Transform player;
    public Transform Kamera;
    public Transform Obje;
    private Camera playerCam;
    public bool buttonacik = false;
    public float mesafe;
    private Ray playerAim;
    public GameObject button;


    void Start()
    {

        buttonacik = false;
    }

    void Update()
    {
        playerCam = Camera.main;
        Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(playerAim, out hit, mesafe))
        {
            GetComponent<CookStoveIngred>();

            if (buttonacik == false && hit.collider.gameObject.tag == "stovebutton" && Input.GetKeyDown(KeyCode.F)) // eşyanın tagını buraya girceksin.
            {
                
                    buttonacik = true;
                    button.transform.localRotation = Quaternion.Euler(90, 1, 90);
                    Debug.Log("acildi");

               

            }


            else if (buttonacik == true && hit.collider.gameObject.tag == "stovebutton" && Input.GetKeyDown(KeyCode.F)) // eşyanın tagını buraya girceksin.
            {
                

                    buttonacik = false;
                    button.transform.localRotation = Quaternion.Euler(90, 1, 0);
                    Debug.Log("kapandi");

                

            }

        }
    }
}