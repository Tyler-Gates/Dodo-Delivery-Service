using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolsManager : MonoBehaviour
{
    [SerializeField] Image tool;
    void Update()
    {
        if (GlobalControl.Instance.tool1 && tool.name == "hud_2") tool.enabled = true;
        else if (GlobalControl.Instance.tool2 && tool.name == "hud_1") tool.enabled = true;
        else if (GlobalControl.Instance.tool3 && tool.name == "hud_3") tool.enabled = true;
        else if (GlobalControl.Instance.tool4 && tool.name == "hud_4") tool.enabled = true;
        else tool.enabled = false;
    }
}
