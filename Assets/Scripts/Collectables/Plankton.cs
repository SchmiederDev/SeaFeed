using UnityEngine;

public class Plankton : MonoBehaviour
{
    [SerializeField]
    int planktonScore = 50;

    [SerializeField]
    float fallingSpeed;

    [SerializeField]
    float xDelta;

    float leftBorder;
    float bottomBorder;

    void Start()
    {
        leftBorder = SeaFeedInterface.SeaFeed.leftLevelBorder;
        bottomBorder = SeaFeedInterface.SeaFeed.bottomLevelBorder;
    }

    void Update()
    {
        if (transform.position.x < leftBorder || transform.position.y < bottomBorder)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(xDelta * Time.fixedDeltaTime, fallingSpeed * Time.fixedDeltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SeaFeedInterface.SeaFeed.FishCharacter.GetScorePoints(planktonScore);
            Destroy(gameObject);
        }
    }
}
