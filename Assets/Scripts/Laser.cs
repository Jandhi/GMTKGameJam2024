using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float ForceMultiplier = 10f;
    public GameObject start;
    public GameObject end;
    

    private void Start()
    {
        start.GetComponent<SpriteRenderer>().enabled = true;
        end.GetComponent<SpriteRenderer>().enabled = true;

        var size = GetComponent<SpriteRenderer>().size;
        start.transform.localPosition = new Vector3(-size.x / 2, 0, -0.1f);
        end.transform.localPosition = new Vector3(size.x / 2, 0, -0.1f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.Die();

            var diff = player.transform.position - transform.position;
            player.GetComponent<Rigidbody2D>().AddForce(diff.normalized * ForceMultiplier);
        }
    }



}

