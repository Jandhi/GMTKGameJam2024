using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Squashable : MonoBehaviour
{
    public static bool IsSquashed = false;
    public static List<Squashable> Squashables = new List<Squashable>();

    public abstract void Squash(Vector3 playerPosition);
    public abstract void Unsquash(Vector3 playerPosition);

    public static void ToggleSquash(Vector3 playerPosition)
    {
        IsSquashed = !IsSquashed;
        if (IsSquashed)
        {
            Debug.Log("Squash");
            SquashAll(playerPosition);
        }
        else
        {
            Debug.Log("Unsquash");
            UnsquashAll(playerPosition);
        }
    }

    public static void SquashAll(Vector3 playerPosition)
    {
        foreach (var squashable in Squashables)
        {
            squashable.Squash(playerPosition);
        }
    }
    
    public static void UnsquashAll(Vector3 playerPosition)
    {
        foreach (var squashable in Squashables)
        {
            squashable.Unsquash(playerPosition);
        }
    }
}
