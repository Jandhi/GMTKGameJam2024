using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LetterJiggle : MonoBehaviour
{
    private Vector3 basePosition;
    private float time;
    public float loopTime = 3f;
    public float yVariance = 5f;
    
    void Start()
    {
        basePosition = this.transform.position;
        time = Random.Range(0f, loopTime);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        while (time > loopTime)
        {
            time -= loopTime;
        }

        transform.position = basePosition + Vector3.up * Mathf.Sin(time / loopTime * Mathf.PI * 2) * yVariance;
    }
}
