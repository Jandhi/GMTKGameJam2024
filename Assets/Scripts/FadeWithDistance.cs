using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeWithDistance : MonoBehaviour
{
    public float FadeMinDistance;
    public float FadeMaxDistance;
    public TMP_Text Text;
    public RawImage img;
    private PlayerController player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        var dist = Mathf.Pow(Mathf.Pow(player.transform.position.x - this.transform.position.x, 2.0f) + Mathf.Pow(player.transform.position.y - this.transform.position.y, 2.0f), 0.5f);
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
        Text.color = WithAlpha(Text.color, amt);
        if (img != null) img.color = WithAlpha(img.color, amt);
    }

    private Color WithAlpha(Color color, float a)
    {
        return new Color(color.r, color.g, color.b, a);
    }
}
