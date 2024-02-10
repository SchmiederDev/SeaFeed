using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardObject : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 1.5f;
    
    private float levelBorderDestination;

    private bool hasReachedDestination = false;

    // Start is called before the first frame update
    void Start()
    {
        levelBorderDestination = SeaFeedInterface.SeaFeed.leftLevelBorder -1f;
    }

    void Update()
    {
        Vector2 destinationPos = new Vector2(levelBorderDestination, transform.position.y);
        float destinationDistance = Vector2.Distance(transform.position, destinationPos);
        
        if (destinationDistance == 0)
            hasReachedDestination = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float movementStep = movementSpeed * Time.deltaTime;
        Vector2 destination = new Vector2 (levelBorderDestination, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, destination, movementStep);

        if (hasReachedDestination) 
            Destroy(gameObject);
    }
}
