using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTransition : MonoBehaviour {
    public Camera TransitionCam;
    private float startTime;
    public float speed = 1.0f;
    private float journeyLength;
    private bool keyPressed = false;
    private bool lerp1,lerp2,lerp3 = false;
    public Vector3 wantPos1;
    public Vector3 wantPos2;
    public Vector3 wantPos3;
    Vector3 wantPosition = new Vector3(-22.51f, 1.74f, -3.2f);

	// Use this for initialization
    //This is a comment
	void Start ()
    {
        TransitionCam.gameObject.transform.position = wantPos1; 
        startTime = Time.time;
        journeyLength = Vector3.Distance(TransitionCam.gameObject.transform.position, wantPos1);
        TransitionCam.gameObject.SetActive(true);
        TransitionCam.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;

        if (Input.GetKeyDown(KeyCode.Space))
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

        if (keyPressed)
        {
            if (TransitionCam.gameObject.transform.position == wantPos1)
            {
                lerp1 = true;
                lerp2 = false;
                lerp3 = false;
            }

            if (TransitionCam.gameObject.transform.position == wantPos2)
            {
                lerp2 = true;
                lerp1 = false;
                lerp3 = false;

            }
            if (TransitionCam.gameObject.transform.position == wantPos3)
            {
                lerp3 = true;
                lerp2 = false;
                lerp1 = false;
            }
        } 

        if(lerp1)
        {
            TransitionCam.gameObject.transform.position = Vector3.Lerp(TransitionCam.gameObject.transform.position, wantPos2, fracJourney);
            keyPressed = false;
        }

        if(lerp2)
        {
            TransitionCam.gameObject.transform.position = Vector3.Lerp(TransitionCam.gameObject.transform.position, wantPos3, fracJourney);
            keyPressed = false;
        }
        if (lerp3)
        {
            TransitionCam.gameObject.transform.position = Vector3.Lerp(TransitionCam.gameObject.transform.position, wantPos1, fracJourney);
            keyPressed = false;
        }

        }
	}
