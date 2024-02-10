using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimController : MonoBehaviour
{   

    [SerializeField]
    private float swimmingSpeed = 0.5f;

    public float swimmingHeightDestination {  get; private set; }

    // Update is called once per frame
    void Update()
    {
        swimmingHeightDestination = SeaFeedInterface.SeaFeed.GameUIHandle.SwimmingBar.value;
        
    }

    private void FixedUpdate()
    {
        float movementStep = swimmingSpeed * Time.fixedDeltaTime;
        Vector2 destination = new Vector2 (transform.position.x, swimmingHeightDestination);
        transform.position = Vector2.MoveTowards(transform.position, destination, movementStep);
    }
}
