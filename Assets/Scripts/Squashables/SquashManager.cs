using System.Collections;
using System.Collections.Generic;
using Pixelplacement;
using UnityEngine;
using UnityEngine.Serialization;

public class SquashManager : Singleton<SquashManager>
{
    public bool IsSquashed = false;
    public bool IsVerticalSquashed = false;
    public bool SquashCoolDownExpired = true;
    public bool IsPorting = false;
    public bool CanSquash => !IsPorting && SquashCoolDownExpired;
    
    public List<Squashable> Squashables = new List<Squashable>();

    public IEnumerator ResetCanSquash(bool isVertical = false)
    {
        yield return new WaitForSeconds(0.5f);
        SquashCoolDownExpired = true;
    }
    
    public void ToggleSquash(Vector3 playerPosition, bool isVertical = false)
    {
        if(!CanSquash) return;
        SquashCoolDownExpired = false;
        
        if (isVertical)
        {
            
            IsVerticalSquashed = !IsVerticalSquashed;
            if (IsVerticalSquashed)
            {
                Debug.Log("Vertical Squash");
                Squashables.ForEach(sq =>
                {
                    if (sq != null)
                    {
                        sq.VerticalSquash(playerPosition);
                    }
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

            StartCoroutine(ResetCanSquash(true));
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
        
        StartCoroutine(ResetCanSquash());
    }
}