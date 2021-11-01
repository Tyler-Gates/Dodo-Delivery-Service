using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;
    public int lives;
    public bool tool1, tool2, tool3, tool4;
    private LivesManager _livesManager;
    void Awake ()   
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
            return;
        }

        if (lives == -1)
            lives = 3;
        _livesManager = FindObjectOfType<LivesManager>();
        _livesManager.SetLivesCount(lives);
    }

    public void SetLivesCount(int newLives)
    {
        lives = newLives;
        _livesManager.SetLivesCount(lives);
    }
    
}
