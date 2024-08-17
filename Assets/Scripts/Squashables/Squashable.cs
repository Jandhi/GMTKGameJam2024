using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public abstract class Squashable : MonoBehaviour
{
    public const float SquashTime = 0.2f;
    public SquashableAnimation Animation;


    public abstract void Squash(Vector3 playerPosition);
    public abstract void Unsquash(Vector3 playerPosition);
    public virtual void VerticalSquash(Vector3 playerPosition) {}
    public virtual void VerticalUnsquash(Vector3 playerPosition) {}

    public void Initialize()
    {
        SquashManager.Instance.Squashables.Add(this);
    }
}
