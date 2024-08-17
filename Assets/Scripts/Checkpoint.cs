using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool isFlagUp = false;
    
    void Start()
    {
        CheckPointManager.Instance.Checkpoints.Add(this);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // Checkpoint already set
        if(isFlagUp) return;
        
        var player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            player.spawnPoint = gameObject;
            CheckPointManager.Instance.SetCheckpoint(this);
        }
    }

    public void RaiseFlag()
    {
        if(isFlagUp) return;
        isFlagUp = true;
    }

    public void LowerFlag()
    {
        if(!isFlagUp) return;
        isFlagUp = false;
    }
}
