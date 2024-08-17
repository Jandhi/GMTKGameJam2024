using System;
using System.Collections;
using System.Collections.Generic;
using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;

public class PositionAndSizeSquashable : PositionSquashable
{
    private SpriteRenderer sprite;
    private BoxCollider2D collider;
    private Vector2 baseSize;
    public bool scaleCollider = true;
    
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
        baseSize = sprite.size;

        // Set collider to take up entire box
        if(scaleCollider) collider.size = new Vector2(Math.Abs(sprite.size.x), Math.Abs(sprite.size.y));
    }
    
    public override void Squash(Vector3 playerPosition)
    {
        SquashPosition(playerPosition);
        SquashSize();
    }

    protected void SquashSize()
    {
        var size = sprite.size;
        Tween.Value(size, new Vector2(size.x / 2, size.y), (val) =>
        {
            sprite.size = val;
        }, SquashTime, 0.0f, Tween.EaseLinear);
        
        var colliderSize = collider.size;
        Tween.Value(colliderSize, new Vector2(colliderSize.x / 2, colliderSize.y), (val) =>
        {
            collider.size = val;
        }, SquashTime, 0.0f, Tween.EaseLinear);
    }

    public override void Unsquash(Vector3 playerPosition)
    {
        UnsquashPosition(playerPosition);
        UnsquashSize();
    }
    
    protected void UnsquashSize()
    {
        var size = sprite.size;
        Tween.Value(size, new Vector2(size.x * 2, size.y), (val) =>
        {
            sprite.size = val;
        }, SquashTime, 0.0f, Tween.EaseLinear);
        
        var colliderSize = collider.size;
        Tween.Value(colliderSize, new Vector2(colliderSize.x * 2, colliderSize.y), (val) =>
        {
            collider.size = val;
        }, SquashTime, 0.0f, Tween.EaseLinear);
    }
    
    // VERTICAL SQUASH
    public override void VerticalSquash(Vector3 playerPosition)
    {
        VerticalSquashPosition(playerPosition);
        VerticalSquashSize();
    }

    protected void VerticalSquashSize()
    {
        var size = sprite.size;
        Tween.Value(size, new Vector2(size.x, size.y / 2), (val) =>
        {
            sprite.size = val;
        }, SquashTime, 0.0f, Tween.EaseLinear);
        
        var colliderSize = collider.size;
        Tween.Value(colliderSize, new Vector2(colliderSize.x, colliderSize.y / 2), (val) =>
        {
            collider.size = val;
        }, SquashTime, 0.0f, Tween.EaseLinear);
    }

    
    
    public override void VerticalUnsquash(Vector3 playerPosition)
    {
        VerticalUnsquashPosition(playerPosition);
        VerticalUnsquashSize();
    }

    protected void VerticalUnsquashSize()
    {
        var size = sprite.size;
        Tween.Value(size, new Vector2(size.x, size.y * 2), (val) =>
        {
            sprite.size = val;
        }, SquashTime, 0.0f, Tween.EaseLinear);
        
        var colliderSize = collider.size;
        Tween.Value(colliderSize, new Vector2(colliderSize.x, colliderSize.y * 2), (val) =>
        {
            collider.size = val;
        }, SquashTime, 0.0f, Tween.EaseLinear);
    }
}