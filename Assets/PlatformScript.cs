using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    [SerializeField] public PlayerController2D player;

    [SerializeField] public PhysicsMaterial2D fric1;
    [SerializeField] public Rigidbody2D platform;
    [SerializeField] public PhysicsMaterial2D fric2;
    void FixedUpdate()
    {
        if (player.grounded)
            platform.sharedMaterial = fric2;
        if (!player.grounded)
            platform.sharedMaterial = fric1;
    }
}
