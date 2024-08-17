using System;
using System.Collections;
using System.Collections.Generic;
using Pixelplacement;
using Sirenix.OdinInspector;
using UnityEngine;

public class SquashableBox : Squashable
{
    public const float SquashTime = 0.2f;
    private SpriteRenderer sprite;
    private BoxCollider2D collider;
    
    // Start is called before the first frame update
    void Start()
    {
        Squashables.Add(this);
        sprite = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();

        // Set collider to take up entire box
        collider.size = new Vector2(Math.Abs(sprite.size.x), Math.Abs(sprite.size.y));
    }
    
    public override void Squash(Vector3 playerPosition)
    {
        var position = transform.position;
        
        var relativePosition = playerPosition - position;
        var finalPosition = new Vector3(
            playerPosition.x - relativePosition.x / 2, 
            position.y,
            position.z);
        Tween.Position(transform, finalPosition, SquashTime, 0.0f, Tween.EaseLinear);
        
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
        var position = transform.position;
        
        var relativePosition = playerPosition - position;
        var finalPosition = new Vector3(
            playerPosition.x - relativePosition.x * 2, 
            position.y,
            position.z);
        Tween.Position(transform, finalPosition, SquashTime, 0.0f, Tween.EaseLinear);
        
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
}