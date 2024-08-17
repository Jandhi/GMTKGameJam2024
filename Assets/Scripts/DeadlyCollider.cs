using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadlyCollider : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.Die();
        }
    }
}
