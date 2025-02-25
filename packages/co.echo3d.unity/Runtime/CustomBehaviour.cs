﻿/**************************************************************************
* Copyright (C) echoAR, Inc. (dba "echo3D") 2018-2021.                    *
* echoAR, Inc. proprietary and confidential.                              *
*                                                                         *
* Use subject to the terms of the Terms of Service available at           *
* https://www.echo3D.co/terms, or another agreement                       *
* between echoAR, Inc. and you, your company or other organization.       *
***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Entry entry;

    [HideInInspector]
    public bool disableRemoteTransformations = false;
    /// <summary>
    /// EXAMPLE BEHAVIOUR
    /// Queries the database and names the object based on the result.
    /// </summary>

    // Use this for initialization
    void Start()
    {
        // Add RemoteTransformations script to object and set its entry
        if (!disableRemoteTransformations)
        {
            this.gameObject.AddComponent<RemoteTransformations>().entry = entry;
        }

        // Qurey additional data to get the name
        string value = "";
        if (entry.getAdditionalData() != null && entry.getAdditionalData().TryGetValue("name", out value))
        {
            // Set name
            this.gameObject.name = value;
        }

        // Set color
        if (this.gameObject.transform.parent.name.Contains("White")){
            colorValue = Color.white;
        }
        else {
            colorValue = Color.black;
        }

        Echo3DService.HologramStart();
    }

    Color colorValue;
    bool colorSet = false;

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponentInChildren<MeshRenderer>() && !colorSet){
            this.gameObject.GetComponentInChildren<MeshRenderer>().material.color = colorValue;
            colorSet = true;
            // Rotate white pieces
            if (colorValue == Color.white)
                this.gameObject.transform.GetChild(0).transform.Rotate(0, -180, 0, Space.Self);
        }
    }
}