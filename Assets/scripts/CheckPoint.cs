using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }//update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") {
            player.startx = transform.position.x;
            player.starty = transform.position.y;
        }
    }
}
