using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SeaStarController : MonoBehaviour
{
    [SerializeField]
    private GameObject DefaultSeaStar;
    public List<SeaStar> SeaStars;
    private int currenStarIndex;

    [SerializeField]
    private float firstSeaStarXPosition = 4.25f;

    private float lastSeaStarPosition;

    // Start is called before the first frame update
    void Awake()
    {
        SeaStars = new List<SeaStar>();
        lastSeaStarPosition = firstSeaStarXPosition;
    }

    public void AddSeaStar()
    {
        if (SeaStars.Count <= SeaFeedInterface.SeaFeed.FishCharacter.SeaStarsMax)
        {
            GameObject SeaStarGO = Instantiate(DefaultSeaStar, transform);
            SeaStarGO.transform.position = new Vector3(lastSeaStarPosition, transform.position.y, 0);
            lastSeaStarPosition--;
            SeaStar seaStar = SeaStarGO.GetComponent<SeaStar>();
            SeaStars.Add(seaStar);
        }
    }

    public void LooseSeaStar()
    {
        currenStarIndex = CalculateStarIndex();
        if (currenStarIndex >= 0 && currenStarIndex < SeaStars.Count)
        {
            SeaStars[currenStarIndex].DisableSeaStar();
        }
    }

    private int CalculateStarIndex()
    {
        int index = SeaStars.Count - 1;
        foreach(SeaStar seaStar in SeaStars)
        {
            if (!seaStar.gameObject.activeSelf)
                index--;
        }
        return index;
    }
}
