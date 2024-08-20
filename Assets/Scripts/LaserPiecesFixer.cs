using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPiecesFixer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(transform.localPosition.x, 0,transform.localPosition.z);       
    }
}
