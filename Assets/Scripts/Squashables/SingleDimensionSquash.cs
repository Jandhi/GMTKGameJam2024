using UnityEngine;

public class SingleDimensionSquash : PositionAndSizeSquashable
{
    public bool IsVertical = false;

    public override void Squash(Vector3 playerPosition)
    {
        if(IsVertical) return;
        base.Squash(playerPosition);
    }

    public override void Unsquash(Vector3 playerPosition)
    {
        if(IsVertical) return;
        base.Unsquash(playerPosition);
    }

    public override void VerticalSquash(Vector3 playerPosition)
    {
        if(!IsVertical) return;
        base.VerticalSquash(playerPosition);
    }

    public override void VerticalUnsquash(Vector3 playerPosition)
    {
        if(!IsVertical) return;
        base.VerticalUnsquash(playerPosition);
    }
}