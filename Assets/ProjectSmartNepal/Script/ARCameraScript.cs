﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCameraScript : MonoBehaviour
{
    public GameObject webPlane;

    GameObject camParent;

    // Use this for initialization 
    void Start()
    {
        camParent = new GameObject("CamParent");
        camParent.transform.position = this.transform.position;
        this.transform.parent = camParent.transform;
        camParent.transform.Rotate(Vector3.right, 90);
        Input.gyro.enabled = true;

        WebCamTexture webcamTexture = new WebCamTexture();
        webPlane.GetComponent<MeshRenderer>().material.mainTexture = webcamTexture;

        if (!Application.isEditor)
        {
            webcamTexture.Play();
        }
        
    }

    void Update()
    {
        if (!Application.isEditor)
        {
            Quaternion rotFix = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z,
                -Input.gyro.attitude.w);
            this.transform.localRotation = rotFix;
        }
    }
}