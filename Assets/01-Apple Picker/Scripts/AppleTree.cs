using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    // Prefab for instantiating apples
    public GameObject applePrefab;

    // Speed at which the AppleTree moves
    public float speed = 1f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float chanceToChangeDirections = 0.1f;

    // Rate at which Apples will be instantiated
    public float secondsBetweenAppleDrops = 1f;

    // Start is called before the first frame update
    void Start()
    {
        // Dropping apples every second
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        GameObject apple = Instantiate<GameObject> (applePrefab);
        apple.transform.position  = transform.position;
        Invoke("DropApple", secondsBetweenAppleDrops);
    }

    // Update is called once per frame
    void Update()
    {
        // Basic Movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        pos.x += 1.0f * 0.01f;
        pos.x += 0.01f;
        transform.position = pos;

        // Changing Directions
        if(pos.x < -leftAndRightEdge) 
        {
            speed = Mathf.Abs(speed); // Move Right
        }
        else if(pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move left
        }
    }

    // Changing Direction Randomly is not time-based because of FixedUpdate()
    void FixedUpdate()
    {
        if(Random.value < chanceToChangeDirections)
        {
            speed *= -1; // Change Directions
        }
    }
}
