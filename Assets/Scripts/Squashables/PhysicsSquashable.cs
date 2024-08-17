using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsSquashable : PositionSquashable
{
    private Rigidbody2D Rigidbody2D;
    public float ForceMultiplier;
    
    void Start()
    {
        Initialize();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void AddForceDelayed(Vector2 force)
    {
        StartCoroutine(DelayedForceCoroutine(force));
    }

    public IEnumerator DelayedForceCoroutine(Vector2 force)
    {
        yield return new WaitForSeconds(SquashTime);
        Rigidbody2D.AddForce(force);
    }
    
    public override void Squash(Vector3 playerPosition)
    {
        var diff = playerPosition - transform.position;
        SquashPosition(playerPosition);
        AddForceDelayed(new Vector2(diff.normalized.x * ForceMultiplier, 0));
    }

    public override void Unsquash(Vector3 playerPosition)
    {
        var diff = playerPosition - transform.position;
        UnsquashPosition(playerPosition);
        AddForceDelayed(new Vector2(-diff.normalized.x * ForceMultiplier, 0));
    }

    public override void VerticalSquash(Vector3 playerPosition)
    {
        var diff = playerPosition - transform.position;
        VerticalSquashPosition(playerPosition);
        AddForceDelayed(new Vector2(0, diff.normalized.y * ForceMultiplier));
    }

    public override void VerticalUnsquash(Vector3 playerPosition)
    {
        var diff = playerPosition - transform.position;
        VerticalUnsquashPosition(playerPosition);
        AddForceDelayed(new Vector2(0, -diff.normalized.y * ForceMultiplier));
    }
}