using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainCanvasHandle : MonoBehaviour
{
    public Slider SwimmingBar;

    public TMP_Text PlanktonScoreTxt;
    // Start is called before the first frame update
    void Awake()
    {
        SwimmingBar = GetComponentInChildren<Slider>();
        PlanktonScoreTxt = GetComponentInChildren<TMP_Text>();
    }

    public void UpdateScoreText(int score)
    {
        PlanktonScoreTxt.text = score.ToString();
    }
}
