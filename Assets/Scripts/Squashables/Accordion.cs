using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accordion : PositionAndSizeSquashable
{
    public override void Squash(Vector3 playerPosition)
    {
        SquashPosition(playerPosition);
        SquashSize();
    }

    public override void Unsquash(Vector3 playerPosition)
    {
        UnsquashPosition(playerPosition);
        UnsquashSize();
    }

    // No vertical squash
    public override void VerticalSquash(Vector3 playerPosition) {}

    public override void VerticalUnsquash(Vector3 playerPosition) {}
}
