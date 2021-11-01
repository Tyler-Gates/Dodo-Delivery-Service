using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    [SerializeField] public SpriteRenderer sr;
    [SerializeField] public string toolName;

    void Start()
    {
        if (GlobalControl.Instance.tool1 && toolName == "tool1")
            sr.enabled = false;
        if (GlobalControl.Instance.tool2 && toolName == "tool2")
            sr.enabled = false;
        if (GlobalControl.Instance.tool3 && toolName == "tool3")
            sr.enabled = false;
        if (GlobalControl.Instance.tool4 && toolName == "tool4")
            sr.enabled = false;
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (toolName)
        {
            case "tool1":
                GlobalControl.Instance.tool1 = true;
                break;
            case "tool2":
                GlobalControl.Instance.tool2 = true;
                break;
            case "tool3":
                GlobalControl.Instance.tool3 = true;
                break;
            case "tool4":
                GlobalControl.Instance.tool4 = true;
                break;
        }

        sr.enabled = false;
    }
}
