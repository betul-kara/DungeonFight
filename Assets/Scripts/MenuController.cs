using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pausePanel.active == false)
        {
            pausePanel.SetActive(true);
            Setting(CursorLockMode.None, 0);
        }
    }
    public void Continue()
    {
        pausePanel.SetActive(false);
        Setting(CursorLockMode.Locked, 1);
    }
    public void Setting(CursorLockMode cursorLockMode, float timeScale)
    {
        Cursor.lockState = cursorLockMode;
        Time.timeScale = timeScale;
    }
    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
        Time.timeScale = 1;
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
