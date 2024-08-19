using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeFalloff : MonoBehaviour
{
    public List<AudioSource> Sources;
    public PlayerController Player;
    public float MaxDistance;
    public float Volume = 1.0f;

    // Update is called once per frame
    void Update()
    {
        var dist_to_player = (this.transform.position - Player.transform.position).magnitude;
        var value = dist_to_player > MaxDistance ? 0 : 1.0f - dist_to_player / MaxDistance;
        Sources.ForEach(src => src.volume = value * Volume);
    }
}
