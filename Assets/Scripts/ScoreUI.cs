using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private IntEventChannelSO updateScoreChannel;
    private TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        updateScoreChannel.onEventRaised += UpdateScore;
    }

    private void OnDisable()
    {
        updateScoreChannel.onEventRaised -= UpdateScore;
    }

    private void UpdateScore(int score)
    {
        int minutes = score / 60;
        int seconds = score % 60;
        scoreText.text = "Temps : " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}