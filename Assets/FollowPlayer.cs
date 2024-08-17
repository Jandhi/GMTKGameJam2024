using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var position = Player.transform.position;
        
        transform.position = new Vector3(
            position.x,
            position.y,
            transform.position.z
        );
    }
}
