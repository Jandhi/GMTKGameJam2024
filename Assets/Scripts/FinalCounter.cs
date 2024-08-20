using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalCounter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var text = GetComponent<TMP_Text>();
        if(GameManager.Instance == null) return;
        text.text = $"{GameManager.Instance.cheeses} cheeses eaten\n{GameManager.Instance.deaths} deaths";
    }
}
