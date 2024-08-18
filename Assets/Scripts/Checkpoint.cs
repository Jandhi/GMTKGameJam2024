using System;
using System.Collections;
using System.Collections.Generic;
using Pixelplacement;
using Unity.VisualScripting;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool isFlagUp = false;
    private float flagBottom;
    private float flagTop;
    private float flagSpeed = 0.2f;
    public SpriteRenderer Pole;
    public SpriteRenderer Flag;
    
    void Start()
    {
        Debug.Log("START");
        CheckPointManager.Instance.Checkpoints.Add(this);
        flagBottom = Flag.transform.position.y;
        flagTop = flagBottom + Pole.size.y - 0.05f;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
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
        var position = Flag.transform.position;
        Tween.Position(Flag.transform, new Vector3(position.x, flagTop, position.z),
            flagSpeed, 0.0f);
    }

    public void LowerFlag()
    {
        if(!isFlagUp) return;
        isFlagUp = false;
        var position = Flag.transform.position;
        Tween.Position(Flag.transform, new Vector3(position.x, flagBottom, position.z),
            flagSpeed, 0.0f);
    }
}
