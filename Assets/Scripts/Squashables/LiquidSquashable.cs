using UnityEngine;

public class LiquidSquashable : PositionAndSizeSquashable
{
    public override void Squash(Vector3 playerPosition)
    {
        SquashPosition(playerPosition);
        SquashSize();
        VerticalUnsquashSize();
    }

    public override void Unsquash(Vector3 playerPosition)
    {
        UnsquashPosition(playerPosition);
        UnsquashSize();
        VerticalSquashSize();
    }
}