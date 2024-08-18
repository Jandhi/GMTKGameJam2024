using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : PositionSquashable
{
    public bool IsOpen = false;
    private Animator _animator;
    private static readonly int IsOpenAnimatorParam = Animator.StringToHash("IsOpen");
    public Portal Pair;
    private bool JustPorted = false;

    public enum OpenState
    {
        Always,
        Squashed,
        Unsquashed,
        VerticalSquashed,
        VerticalUnsquashed
    }

    public OpenState OpenWhen = OpenState.Unsquashed;

    void Open()
    {
        _animator.SetBool(IsOpenAnimatorParam, true);
        IsOpen = true;
    }

    void Close()
    {
        _animator.SetBool(IsOpenAnimatorParam, false);
        IsOpen = false;
    }

    void Start()
    {
        Initialize();
        _animator = GetComponent<Animator>();
        if(OpenWhen is OpenState.Always or OpenState.Unsquashed or OpenState.VerticalUnsquashed) Open();
    }
    
    public override void Squash(Vector3 playerPosition)
    {
        base.Squash(playerPosition);
        
        if (OpenWhen == OpenState.Squashed)
        {
            Open();
        } 
        else if (OpenWhen == OpenState.Unsquashed)
        {
            Close();
        }
    }

    public override void Unsquash(Vector3 playerPosition)
    {
        base.Unsquash(playerPosition);
        
        if (OpenWhen == OpenState.Squashed)
        {
            Close();
        } 
        else if (OpenWhen == OpenState.Unsquashed)
        {
            Open();
        }
    }

    public override void VerticalSquash(Vector3 playerPosition)
    {
        base.VerticalSquash(playerPosition);
        
        if (OpenWhen == OpenState.VerticalSquashed)
        {
            Open();
        } 
        else if (OpenWhen == OpenState.VerticalUnsquashed)
        {
            Close();
        }
    }

    public override void VerticalUnsquash(Vector3 playerPosition)
    {
        base.VerticalUnsquash(playerPosition);
        
        if (OpenWhen == OpenState.VerticalSquashed)
        {
            Close();
        } 
        else if (OpenWhen == OpenState.VerticalUnsquashed)
        {
            Open();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
        var player = other.GetComponent<PlayerController>();
        if (player != null)
        {
            if(!IsOpen || Pair.JustPorted) return;
            SquashManager.Instance.IsPorting = true;
            
            JustPorted = true;
            StartCoroutine(Suction(player));
        }
    }

    IEnumerator Suction(PlayerController player)
    {
        player.SuckIn(transform.position);
        yield return new WaitForSeconds(player.SuckDuration);
        player.SuckOut(Pair.transform.position);
        yield return new WaitForSeconds(1.0f);
        JustPorted = false;
        SquashManager.Instance.IsPorting = false;
    }
}
