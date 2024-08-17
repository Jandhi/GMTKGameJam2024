using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public abstract class Squashable : MonoBehaviour
{
    public static bool IsSquashed = false;
    public static bool IsVerticalSquashed = false;
    public const float SquashTime = 0.2f;
    public static List<Squashable> Squashables = new List<Squashable>();


    public abstract void Squash(Vector3 playerPosition);
    public abstract void Unsquash(Vector3 playerPosition);
    public virtual void VerticalSquash(Vector3 playerPosition) {}
    public virtual void VerticalUnsquash(Vector3 playerPosition) {}

    public static void ToggleSquash(Vector3 playerPosition, bool isVertical = false)
    {
        if (isVertical)
        {
            IsVerticalSquashed = !IsVerticalSquashed;
            if (IsVerticalSquashed)
            {
                Debug.Log("Vertical Squash");
                Squashables.ForEach(sq =>
                {
                    if (sq != null) sq.VerticalSquash(playerPosition);
                });
            }
            else
            {
                Debug.Log("Vertical Unsquash");
                Squashables.ForEach(sq =>
                {
                    if (sq != null) sq.VerticalUnsquash(playerPosition);
                });
            }
            return;
        }
        
        IsSquashed = !IsSquashed;
        if (IsSquashed)
        {
            Debug.Log("Squash");
            Squashables.ForEach(sq =>
            {
                if (sq != null) sq.Squash(playerPosition);
            });
        }
        else
        {
            Debug.Log("Unsquash");
            Squashables.ForEach(sq =>
            {
                if (sq != null) sq.Unsquash(playerPosition);
            });
        }
    }
}
