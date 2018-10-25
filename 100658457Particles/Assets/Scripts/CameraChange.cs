using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraChange : MonoBehaviour {

    public Transform Player1;

    public Camera Cam1;

    public Camera Cam2;

    public Camera Cam3;

    public KeyCode Key;

    // Use this for initialization
    void Start()
    {


        Cam1.gameObject.SetActive(true);
        Cam2.gameObject.SetActive(false);
        Cam3.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            Cam1.gameObject.SetActive(false);
            Cam2.gameObject.SetActive(true);
            Cam3.gameObject.SetActive(false);
        }
        else
        {
            Cam1.gameObject.SetActive(true);
            Cam2.gameObject.SetActive(false);
            Cam3.gameObject.SetActive(false);
        }
    }
}
