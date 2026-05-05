using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private IntEventChannelSO collectObstacleChannel;
    [SerializeField] private IntEventChannelSO updateScoreChannel;
    [SerializeField] private IntEventChannelSO collectTransistorChannel;
    [SerializeField] private IntEventChannelSO updateTransistorChannel;
    public Material[] materialsWave;

    private int score = 0;
    private int transistor = 0;
    private float elapsedTime = 0f;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void Start()
    {
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        updateScoreChannel.RaiseEvent(this.score);
        updateTransistorChannel.RaiseEvent(this.transistor);
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        score = Mathf.FloorToInt(elapsedTime);
        updateScoreChannel.RaiseEvent(score);
    }

    private void OnEnable()
    {
        collectTransistorChannel.onEventRaised += AddTransistor;
    }

    private void OnDisable()
    {
        collectTransistorChannel.onEventRaised -= AddTransistor;
    }


    public void AddTransistor(int transistor)
    {
        this.transistor += transistor;
        updateTransistorChannel.RaiseEvent(this.transistor);
    }

    public void GameOverScene()
    {
        RecupScore.lastScore = Mathf.RoundToInt(elapsedTime);
        RecupTransistor.lastTransistor = transistor;
        SceneManager.LoadScene("GameOver");
    }
}
