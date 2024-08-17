using UnityEngine;

public class LiquidSquashable : PositionAndSizeSquashable
{
    public override void Squash(Vector3 playerPosition)
    {
        base.Squash(playerPosition);
        base.VerticalUnsquash(playerPosition);
    }

    public override void Unsquash(Vector3 playerPosition)
    {
        base.Unsquash(playerPosition);
        base.VerticalSquash(playerPosition);
    }

    public override void VerticalSquash(Vector3 playerPosition)
    {
        base.VerticalSquash(playerPosition);
        base.Unsquash(playerPosition);
    }

    public override void VerticalUnsquash(Vector3 playerPosition)
    {
        base.VerticalUnsquash(playerPosition);
        base.Squash(playerPosition);
    }
}