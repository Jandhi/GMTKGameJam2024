using System;
using System.Collections;
using System.Collections.Generic;
using Pixelplacement;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cheese : MonoBehaviour
{
    private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.GetComponent<ParticleEffectController>().PlayCheeseVFX();
            StartCoroutine(Eat());
        }
    }

    IEnumerator Eat()
    {
        Tween.LocalScale(transform, Vector3.zero, 0.5f, 0.0f);
        audio.pitch = Random.Range(0.8f, 1.25f);
        audio.Play();
        yield return new WaitForSeconds(0.2f);
        audio.pitch = Random.Range(0.8f, 1.25f);
        audio.Play();
        yield return new WaitForSeconds(0.2f);
        audio.pitch = Random.Range(0.8f, 1.25f);
        audio.Play();
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
