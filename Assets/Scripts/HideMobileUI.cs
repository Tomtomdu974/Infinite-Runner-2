using UnityEngine;

public class HideMobileUI : MonoBehaviour
{

    void Start()
    {
        // Désactive l'objet sur PC/Mac, garde sur mobile
#if UNITY_STANDALONE || UNITY_EDITOR
        gameObject.SetActive(false);
#endif
    }

}
