using UnityEngine;
using TMPro;

public class RecupScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public static int lastScore;

    void Start()
    {
        int score = lastScore;
        int minutes = score / 60;
        int seconds = score % 60;
        scoreText.text = "Temps : " + minutes.ToString("00") + ":" + seconds.ToString("00");
        Debug.Log("Last Score: " + score);
    }
}
