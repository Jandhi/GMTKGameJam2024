using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public PlayerController Player;
    public float cameraSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Don't follow dead players
        if(Player == null || Player.isDead) return;

        var position = Player.transform.position;
        var target = new Vector3(
            position.x,
            position.y,
            transform.position.z
        );

        var direction_vector = target - transform.position;
        if (direction_vector.magnitude < cameraSpeed)
        {
            this.transform.position = target;
        }
        else
        {
            this.transform.position += direction_vector.normalized * cameraSpeed;
        }
    }
}
