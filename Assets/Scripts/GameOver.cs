using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    private LivesManager _livesManager;
    void Start()
    {
        _livesManager =  FindObjectOfType<LivesManager>();
    }
    void Update()
    {
        _livesManager = FindObjectOfType<LivesManager>();
        GlobalControl.Instance.lives = -1;
        _livesManager.SetLivesCount(GlobalControl.Instance.lives);
        if (!Input.GetKey(KeyCode.R)) return;
        GlobalControl.Instance.lives = 3;
        _livesManager = FindObjectOfType<LivesManager>();
        _livesManager.SetLivesCount(3);
        SceneManager.LoadScene(1);
    }
}
