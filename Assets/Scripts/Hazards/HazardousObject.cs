using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardousObject : StandardObject
{
    [SerializeField]
    private int damage = 1;

    private bool hasAlreadyHit = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!hasAlreadyHit)
            {
                SeaFeedInterface.SeaFeed.FishCharacter.GetHit(damage);
                hasAlreadyHit = true;
            }
        }
    }
}
