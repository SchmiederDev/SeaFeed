using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SeaStarController : MonoBehaviour
{
    public SeaStar[] SeaStars;
    private int currenStarIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
        SeaStars = GetComponentsInChildren<SeaStar>();
    }

    public void LooseSeaStar()
    {
        if (SeaStars.Length > 0 && currenStarIndex >= 0 && currenStarIndex < SeaStars.Length)
        {
            SeaStars[currenStarIndex].DisableSeaStar();
            currenStarIndex++;
        }
    }
}
