using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bbraycast : MonoBehaviour
{

    // Use this for initialization
    void Start() { }
    public float mesafe;
    private Ray playerAim;
    private Camera playerCam;
    GameObject button;

    // Update is called once per frame
    void Update()
    {
        playerCam = Camera.main;
        Ray playerAim = playerCam.GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        //crosshair.color = Color.red;
        RaycastHit hit;
        if (Physics.Raycast(playerAim, out hit, mesafe))
        {
            if (hit.collider.gameObject.tag == "stovebutton" && Input.GetKeyDown(KeyCode.F))
            {
               
            }
        }
    }
}
