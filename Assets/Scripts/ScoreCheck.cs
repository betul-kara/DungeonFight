using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCheck : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI collectedText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            StartCoroutine(GetFalse(other.gameObject));
        }
    }
    IEnumerator GetFalse(GameObject point)
    {
        yield return new WaitForSeconds(.2f);
        point.gameObject.SetActive(false);
        collectedText.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        collectedText.gameObject.SetActive(false);
    }
}
