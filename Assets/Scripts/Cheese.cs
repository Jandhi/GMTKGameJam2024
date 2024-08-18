using System;
using System.Collections;
using System.Collections.Generic;
using Pixelplacement;
using UnityEngine;

public class Cheese : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            StartCoroutine(Eat());
        }
    }

    IEnumerator Eat()
    {
        Tween.LocalScale(transform, Vector3.zero, 0.5f, 0.0f);
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
}
