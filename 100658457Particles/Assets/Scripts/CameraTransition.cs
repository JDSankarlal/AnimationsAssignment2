using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour {
    public Camera TransitionCam;
    private float startTime;
    public float speed = 1.0f;
    private float journeyLength;
    private bool keyPressed = false;
    public Vector3 wantPos1;
    public Vector3 wantPos2;
    public Vector3 wantPos3;
    Vector3 wantPosition = new Vector3(-22.51f, 1.74f, -3.2f);

	// Use this for initialization
    //This is a comment
	void Start ()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(TransitionCam.gameObject.transform.position, wantPos1);
        TransitionCam.gameObject.SetActive(true);
        TransitionCam.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKeyDown(KeyCode.C))
        {
            keyPressed = true;   
        }
		
        if (TransitionCam.gameObject.transform.position == wantPos1)
        {
            journeyLength = Vector3.Distance(TransitionCam.gameObject.transform.position, wantPos2);
        }

        if (TransitionCam.gameObject.transform.position == wantPos2)
        {
            journeyLength = Vector3.Distance(TransitionCam.gameObject.transform.position, wantPos3);
        }

        if (TransitionCam.gameObject.transform.position == wantPos3)
        {
            journeyLength = Vector3.Distance(TransitionCam.gameObject.transform.position, wantPos1);
        }

        if (!(!keyPressed))
        {
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;

            if (TransitionCam.gameObject.transform.position == wantPos1)
            {
                TransitionCam.gameObject.transform.position = Vector3.Lerp(TransitionCam.gameObject.transform.position, wantPos2, fracJourney);
            }

            else if (TransitionCam.gameObject.transform.position == wantPos2)
            {
                TransitionCam.gameObject.transform.position = Vector3.Lerp(TransitionCam.gameObject.transform.position, wantPos3, fracJourney);
            }

            else if (TransitionCam.gameObject.transform.position == wantPos3)
            {
                TransitionCam.gameObject.transform.position = Vector3.Lerp(TransitionCam.gameObject.transform.position, wantPos1, fracJourney);
            }
        }
	}
}
