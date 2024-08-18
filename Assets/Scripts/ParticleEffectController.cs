using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectController : MonoBehaviour
{
    [SerializeField] Transform vfxContainer;
    [SerializeField] ParticleSystem cheeseVFX;
    [SerializeField] ParticleSystem bloodVFX;

    private SpriteRenderer spr;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //match sprite rendering direction
        int facingDir = 1;
        if(spr.flipX) {facingDir =-1;}
        vfxContainer.localScale = new Vector3(facingDir ,1,1);

        //test keys
        if((Input.GetKeyDown("q")))
        {
            PlayCheeseVFX();
        }
        if((Input.GetKeyDown("e")))
        {
            PlayBloodVFX();
        }
    }

    public void PlayCheeseVFX()
    {
        cheeseVFX.Play();
    }

    public void PlayBloodVFX()
    {
        bloodVFX.Play();
    }
}
