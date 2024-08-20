using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public AudioSource Source;
    
    public void Load(int buildIndex)
    {
        if(Source != null) Source.Play();
        SceneManager.LoadScene(buildIndex);
    }
}
