using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public int buildIndex;
    
    public void Load()
    {
        SceneManager.LoadScene(buildIndex);
    }
}
