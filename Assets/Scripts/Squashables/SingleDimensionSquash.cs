using UnityEngine;

public class SingleDimensionSquash : PositionAndSizeSquashable
{
    public bool IsVertical = false;

    public override void Squash(Vector3 playerPosition)
    {
        SquashPosition(playerPosition);
        if (!IsVertical)
        {
            SquashSize();
        }
    }

    public override void Unsquash(Vector3 playerPosition)
    {
        UnsquashPosition(playerPosition);
        if (!IsVertical)
        {
            UnsquashSize();
        }
    }

    public override void VerticalSquash(Vector3 playerPosition)
    {
        VerticalSquashPosition(playerPosition);
        if (IsVertical)
        {
            VerticalSquashSize();
        }
    }

    public override void VerticalUnsquash(Vector3 playerPosition)
    {
        VerticalUnsquashPosition(playerPosition);
        if (IsVertical)
        {
            VerticalUnsquashSize();
        }
    }
}