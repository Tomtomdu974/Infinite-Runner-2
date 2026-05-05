using UnityEngine;
using TMPro;
using System.Collections;

public class Transistor : MonoBehaviour
{
    [SerializeField] private GameObject transistorPrefab;
    [SerializeField] private float checkRadius = 1f;

    IEnumerator spawnTransistor()
    {
        float spawnInterval = Random.Range(0.5f, 3f);
        yield return new WaitForSeconds(spawnInterval);
        if (IsPositionFree())
        {
            GameObject go = Instantiate(transistorPrefab, transform.position, Quaternion.identity);
            go.GetComponent<Transistor>();
        }
        StartCoroutine(spawnTransistor());
    }

    private bool IsPositionFree()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius);

        foreach (Collider col in colliders)
        {
            if (col.gameObject == gameObject) continue;

            if (col.CompareTag("Collectable") || col.CompareTag("Transistor"))
            {
                return false;
            }
        }

        return true;
    }

    private void OnEnable()
    {
        StartCoroutine(spawnTransistor());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}

