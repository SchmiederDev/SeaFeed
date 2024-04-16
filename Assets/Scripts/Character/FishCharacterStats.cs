using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCharacterStats : MonoBehaviour
{   

    public int PlanktonScore { get; private set; }

    [SerializeField]
    private int growthThreshold = 100;

    [SerializeField]
    private float growthRate = 0.1f;

    [SerializeField]
    private float maxCharacterScale = 3f;

    [SerializeField]
    private int seaStarsMax = 5;
    public int SeaStarsMax { get { return seaStarsMax; } }

    public int SeaStarsTotal { get; private set; }
    public int SeaStars { get; private set; }

    public int CharacterLevel { get; private set; }

    public bool CharacterDied { get; private set; } = false;

    public delegate void PlanktonScoreChanged(int currentScore);
    public PlanktonScoreChanged OnPlanktonScoreChanged;

    public delegate void SeaStarsChanged();
    public SeaStarsChanged OnSeaStarsChanged;

    public delegate void CharacterDeathDelegate();
    public CharacterDeathDelegate OnCharacterDeath;

    private void Awake()
    {
        SeaStarsTotal = 1;
        SeaStars = SeaStarsTotal;
        CharacterLevel = 1;
        Debug.Log("Character level: " + CharacterLevel);
    }

    public void GetScorePoints(int points)
    {
        PlanktonScore += points;
        
        if (OnPlanktonScoreChanged != null)
            OnPlanktonScoreChanged.Invoke(PlanktonScore);

        CheckGrowthStatus();
    }

    public void GetHit(int damage)
    {
        int updatedHealth = SeaStars - damage;
        
        if (updatedHealth >= 0)
        {
            SeaStars -= damage;

            if (OnSeaStarsChanged != null)
                OnSeaStarsChanged.Invoke();

            if (SeaStars == 0)
            {
                CharacterDied = true;
                if (OnCharacterDeath != null)
                    OnCharacterDeath.Invoke();
            }
        }

        else
        {
            CharacterDied = true;
            if (OnCharacterDeath != null)
                OnCharacterDeath.Invoke();
        }
    }

    private void CheckGrowthStatus()
    {
        if (PlanktonScore >= growthThreshold)
        {
            CharacterLevel++;

            if (SeaStarsTotal < seaStarsMax)
            {
                SeaStarsTotal++;
                SeaStars = SeaStarsTotal;
                SeaFeedInterface.SeaFeed.StarContoller.AddSeaStar();
            }

            float newCharacterScale = transform.localScale.x + growthRate;

            if (newCharacterScale <= maxCharacterScale)
            {
                transform.localScale = new Vector3(newCharacterScale, newCharacterScale, 1);
                growthThreshold += growthThreshold;
            }
        }
    }
}
