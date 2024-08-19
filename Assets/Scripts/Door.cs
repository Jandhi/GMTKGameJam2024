using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int NextSceneIndex;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.SuckIn(transform.position);
            GetComponent<AudioSource>().Play();
            StartCoroutine(EndLevel());
        }
    }

    IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(NextSceneIndex);
    }
}
