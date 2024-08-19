using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accordion : PositionAndSizeSquashable
{
    public AudioSource SquashAudio;
    public AudioSource UnsquashAudio;
    
    public override void Squash(Vector3 playerPosition)
    {
        SquashPosition(playerPosition);
        SquashSize();
        SquashAudio.Play();
    }

    public override void Unsquash(Vector3 playerPosition)
    {
        UnsquashPosition(playerPosition);
        UnsquashSize();
        UnsquashAudio.Play();
    }

    // No vertical squash
    public override void VerticalSquash(Vector3 playerPosition)
    {
        VerticalSquashPosition(playerPosition);
    }

    public override void VerticalUnsquash(Vector3 playerPosition)
    {
        VerticalUnsquashPosition(playerPosition);
    }
}
