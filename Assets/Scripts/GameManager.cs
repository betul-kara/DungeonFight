using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] GameObject winText;

    float totalTime = 20f;
    float time = 0;

    private void Start()
    {
        time = totalTime;
    }
    private void Update()
    {
        if (Player.Instance.isSpawned)
        {
            if (time > 0)
            {
                time -= Time.deltaTime;
                timeText.text = "TIME : " + time.ToString("F0");
            }
        }
        if (time <= 0)
        {
            StartCoroutine(Win());
        }
    }
    IEnumerator Win()
    {
        time = totalTime;
        Player.Instance.isSpawned = false;

        winText.SetActive(true);
        yield return new WaitForSeconds(2);
        winText.SetActive(false);
    }
}

// 4.5 ya da 4.6 yükseliyor