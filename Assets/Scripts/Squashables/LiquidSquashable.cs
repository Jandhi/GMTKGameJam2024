using Pixelplacement;
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
    
    protected override void VerticalUnsquashSize()
    {
        base.VerticalUnsquashSize();
        
        var colliderOffset = collider.offset;
        Tween.Value(colliderOffset.y, colliderOffset.y * 2, (val) =>
        {
            collider.offset = new Vector2(collider.offset.x, val);
        }, SquashTime, 0.0f, Animation.Curve);
    }

    protected override void VerticalSquashSize()
    {
        base.VerticalSquashSize();
        
        var colliderOffset = collider.offset;
        Tween.Value(colliderOffset.y, colliderOffset.y / 2, (val) =>
        {
            collider.offset = new Vector2(collider.offset.x, val);
        }, SquashTime, 0.0f, Animation.Curve);
    }
}