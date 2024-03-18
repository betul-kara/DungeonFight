using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] GameObject winPanel;

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
            Win();
        }
    }

    private void Win()
    {
        time = totalTime;
        winPanel.SetActive(true);
        Player.Instance.isSpawned = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}

// 4.5 ya da 4.6 yükseliyor