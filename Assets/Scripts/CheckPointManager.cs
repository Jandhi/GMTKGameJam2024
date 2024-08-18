using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pixelplacement;
using UnityEngine;

public class CheckPointManager : Singleton<CheckPointManager>
{
    public List<Checkpoint> Checkpoints = new List<Checkpoint>();
    public PlayerController Player;

    public void SetCheckpoint(Checkpoint checkpoint)
    {
        Debug.Log("SET CHECKPOINT");
        Player.spawnPoint = checkpoint.gameObject;
        checkpoint.RaiseFlag();
            
        foreach (var otherCheckpoint in Checkpoints
                     .Where(otherCheckpoint => otherCheckpoint != checkpoint))
        {
            otherCheckpoint.LowerFlag();
        }
    }
}
