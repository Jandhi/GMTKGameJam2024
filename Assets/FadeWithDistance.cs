using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FadeWithDistance : MonoBehaviour
{
    public float FadeMinDistance;
    public float FadeMaxDistance;
    public TMP_Text Text;
    private PlayerController player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        var dist = Math.Abs(player.transform.position.x - this.transform.position.x);
        if (dist >= FadeMaxDistance)
        {
            SetFade(0);
        }
        else if (dist <= FadeMinDistance)
        {
            SetFade(1.0f);
        }
        else
        {
            SetFade(1.0f - (dist - FadeMinDistance) / (FadeMaxDistance - FadeMinDistance) );
        }
    }

    private void SetFade(float amt)
    {
        Text.color = Text.color.WithAlpha(amt);
    }
}
