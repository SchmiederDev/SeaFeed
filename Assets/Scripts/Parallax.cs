using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField]
    private float shiftingSpeed = 0.5f;

    [SerializeField]
    float border = -16.95f;

    [SerializeField]
    float startingPos = 21.3f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < border)
        {
            transform.position = new Vector3(startingPos, transform.position.y, 0);
        }

        transform.Translate(Vector2.left * shiftingSpeed * Time.deltaTime);
    }
}
