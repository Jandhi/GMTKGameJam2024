using UnityEngine;

public class SingleDimensionSquash : PositionAndSizeSquashable
{
    public bool IsVertical = false;
    public bool IsRotated = false;

    public override void Squash(Vector3 playerPosition)
    {
        SquashPosition(playerPosition);
        if (!IsVertical)
        {
            if (IsRotated)
            {
                VerticalSquashSize();
            }
            else
            {
                SquashSize();
            }
        }
    }

    public override void Unsquash(Vector3 playerPosition)
    {
        UnsquashPosition(playerPosition);
        if (!IsVertical)
        {
            if (IsRotated)
            {
                SquashSize();    
            }
            else
            {
                UnsquashSize();
            }
        }
    }

    public override void VerticalSquash(Vector3 playerPosition)
    {
        VerticalSquashPosition(playerPosition);
        if (IsVertical)
        {
            if (IsRotated)
            {
                SquashSize();
            }
            else
            {
                VerticalSquashSize();
            }
        }
    }

    public override void VerticalUnsquash(Vector3 playerPosition)
    {
        VerticalUnsquashPosition(playerPosition);
        if (IsVertical)
        {
            if (IsRotated)
            {
                UnsquashSize();
            }
            else
            {
                VerticalUnsquashSize();
            }
        }
    }
}