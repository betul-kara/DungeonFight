using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] GameObject[] winPanels;

    float totalTime = 20f;
    float time = 0;

    private void Start()
    {
        time = totalTime;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
        }

        CheckTime();
    }

    private void CheckTime()
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
            if (Player.Instance.isSpawned)
            {
                Win();
            }
        }
    }

    private void Win()
    {
        time = totalTime;
        winPanels[LevelManager.Level].SetActive(true);
        Player.Instance.isSpawned = false;
    }
}
