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
        
        FishCharacter = fishCharacterGO.GetComponent<FishCharacterStats>();
        FishCharacter.OnPlanktonScoreChanged += GameUIHandle.UpdateScoreText;
        
        StarContoller = GetComponentInChildren<SeaStarController>();
        FishCharacter.OnSeaStarsChanged += StarContoller.LooseSeaStar;

        FishCharacter.OnCharacterDeath += RestartGame;
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
