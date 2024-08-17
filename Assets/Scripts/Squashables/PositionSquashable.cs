using Pixelplacement;
using UnityEngine;

public class PositionSquashable : Squashable
{
    
    void Start()
    {
        Initialize();
    }

    public override void Squash(Vector3 playerPosition)
    {
        SquashPosition(playerPosition);
    }

    protected void SquashPosition(Vector3 playerPosition)
    {
        var position = transform.position;
        
        var relativePosition = playerPosition - position;
        var finalPosition = new Vector3(
            playerPosition.x - relativePosition.x / 2, 
            position.y,
            position.z);
        Tween.Position(transform, finalPosition, SquashTime, 0.0f, Animation.Curve);
    }

    public override void Unsquash(Vector3 playerPosition)
    {
        UnsquashPosition(playerPosition);
    }

    protected void UnsquashPosition(Vector3 playerPosition)
    {
        var position = transform.position;
        
        var relativePosition = playerPosition - position;
        var finalPosition = new Vector3(
            playerPosition.x - relativePosition.x * 2, 
            position.y,
            position.z);
        Tween.Position(transform, finalPosition, SquashTime, 0.0f, Animation.Curve);
    }
    
    // VERTICAL SQUASH
    public override void VerticalSquash(Vector3 playerPosition)
    {
        VerticalSquashPosition(playerPosition);
    }

    protected void VerticalSquashPosition(Vector3 playerPosition)
    {
        var position = transform.position;
        
        var relativePosition = playerPosition - position;
        var finalPosition = new Vector3(
            
            position.x,
            playerPosition.y - relativePosition.y / 2, 
            position.z);
        Tween.Position(transform, finalPosition, SquashTime, 0.0f, Animation.Curve);
    }

    public override void VerticalUnsquash(Vector3 playerPosition)
    {
        VerticalUnsquashPosition(playerPosition);
    }

    public void VerticalUnsquashPosition(Vector3 playerPosition)
    {
        var position = transform.position;
        
        var relativePosition = playerPosition - position;
        var finalPosition = new Vector3(
            
            position.x,
            playerPosition.y - relativePosition.y * 2, 
            position.z);
        Tween.Position(transform, finalPosition, SquashTime, 0.0f, Animation.Curve);
    }
}