using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAndForth : MonoBehaviour //right and left
{
    public double amountToMove;
    public float speed;
    public float rotationSpeed;//this is for rotating the enemy
    private float startx;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        startx = gameObject.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < startx + amountToMove && direction == 0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x + speed, gameObject.transform.position.y);
            gameObject.transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime, Space.World);

        }
        else if (gameObject.transform.position.x >= startx + amountToMove && direction == 0) {
        direction = 1;  
        }
        else if (gameObject.transform.position.x > startx  && direction == 1)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x - speed, gameObject.transform.position.y);
            gameObject.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.World);
        }
        else if (gameObject.transform.position.x <= startx && direction == 1)
        {
            direction = 0;
        }
    }
}
