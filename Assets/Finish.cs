using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] public SpriteRenderer needMore;
    [SerializeField] public SpriteRenderer thankYou;
    [SerializeField] public SpriteRenderer tool1;
    [SerializeField] public SpriteRenderer tool2;
    [SerializeField] public SpriteRenderer tool3;
    [SerializeField] public SpriteRenderer tool4;

    private void  OnTriggerEnter2D(Collider2D other)
    {
        if (GlobalControl.Instance.tool1) tool1.enabled = true;
        if (GlobalControl.Instance.tool2) tool2.enabled = true;
        if (GlobalControl.Instance.tool3) tool3.enabled = true;
        if (GlobalControl.Instance.tool4) tool4.enabled = true;
        if (tool1.enabled && tool2.enabled && tool3.enabled && tool4.enabled)
        {
            thankYou.enabled = true;
            StartCoroutine(Win());
        }
        else
            needMore.enabled = true;
    }

    private IEnumerator Win()
    {
        yield return new WaitForSeconds(2);
        GlobalControl.Instance.tool1 = false;
        GlobalControl.Instance.tool2 = false;
        GlobalControl.Instance.tool3 = false;
        GlobalControl.Instance.tool4 = false;
        GlobalControl.Instance.lives = -1;
        SceneManager.LoadScene(4);
    }
}
