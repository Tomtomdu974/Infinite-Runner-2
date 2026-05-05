using UnityEngine;
using UnityEngine.UI;

public class TouchControls : MonoBehaviour
{
    [SerializeField] private Button buttonLane1; // Pour sphere1 (W)
    [SerializeField] private Button buttonLane2; // Pour sphere2 (E)
    [SerializeField] private Button buttonLane3; // Pour sphere3 (Q)

    [SerializeField] private PlayerController playerController;

    void Start()
    {
        if (playerController == null)
        {
            playerController = FindAnyObjectByType<PlayerController>();
        }

        buttonLane1.onClick.AddListener(() => playerController.ChangeSphereColor(1));
        buttonLane2.onClick.AddListener(() => playerController.ChangeSphereColor(2));
        buttonLane3.onClick.AddListener(() => playerController.ChangeSphereColor(3));
    }

}
