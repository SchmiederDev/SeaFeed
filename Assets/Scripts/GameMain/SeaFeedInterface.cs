using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeaFeedInterface : MonoBehaviour
{
    public static SeaFeedInterface SeaFeed;

    [SerializeField]
    GameObject GameUI;

    public MainCanvasHandle GameUIHandle;

    public float leftLevelBorder;
    public float rightLevelBorder;
    
    public float topLevelBorder;
    public float bottomLevelBorder;

    [SerializeField]
    private GameObject fishCharacterGO;

    public FishCharacterStats FishCharacter;

    public SeaStarController StarContoller;

    [SerializeField]
    private float restartTimeFrame = 1f;

    void Awake()
    {
        if (SeaFeed == null)
            SeaFeed = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GameUIHandle = GameUI.GetComponent<MainCanvasHandle>();        
        
        InitFishCharacter();
        InitSeaStars();
    }

    private void InitFishCharacter()
    {
        FishCharacter = fishCharacterGO.GetComponent<FishCharacterStats>();
        FishCharacter.OnPlanktonScoreChanged += GameUIHandle.UpdateScoreText;
        FishCharacter.OnCharacterDeath += RestartGame;
    }

    private void InitSeaStars()
    {
        StarContoller = GetComponentInChildren<SeaStarController>();
        for (int i = 0; i < FishCharacter.SeaStarsTotal; i++)
        {
            StarContoller.AddSeaStar();
        }
        FishCharacter.OnSeaStarsChanged += StarContoller.LooseSeaStar;
    }

    private void RestartGame()
    {
        StartCoroutine(ResetScene());
    }

    private IEnumerator ResetScene()
    {
        yield return new WaitForSecondsRealtime(restartTimeFrame);
        SceneManager.LoadScene("Underwater");
    }
}
