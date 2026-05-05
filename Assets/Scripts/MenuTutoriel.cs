using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuTutoriel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tutorielText;
    [SerializeField] private GameObject touchesTextAZERTY;
    [SerializeField] private GameObject touchesTextQWERTY;
    [SerializeField] private GameObject descriptionText;

    void Start()
    {
        tutorielText.text = "Tutoriel";
        touchesTextAZERTY.SetActive(true);
        touchesTextQWERTY.SetActive(true);
        descriptionText.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            touchesTextAZERTY.SetActive(false);
            touchesTextQWERTY.SetActive(false);
            descriptionText.SetActive(false);
            Game();
        }

#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Game();
        }
#endif
    }

    public void Game()
    {
        SceneManager.LoadScene("Game");
    }
}
