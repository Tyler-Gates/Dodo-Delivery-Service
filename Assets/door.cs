using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class door : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private void OnTriggerStay2D(Collider2D other)
    {
        var player = other.GetComponent<PlayerController2D>();
        if (!(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))) return;
        animator.Play(SceneManager.GetActiveScene().buildIndex == 2 ? "doorl_open" : "door_open");
        player.open = true;
        player.ChangeLevel();
    }
}
