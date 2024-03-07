using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] TMP_Dropdown qualityDropdown;
    string[] qualityLevels;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pausePanel.activeSelf == false)
        {
            pausePanel.SetActive(true);
            Setting(CursorLockMode.None, 0);
        }
        SetupQuality();
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
    private void SetupQuality()
    {
        qualityLevels = QualitySettings.names;
        qualityDropdown.ClearOptions();
        qualityDropdown.AddOptions(new List<string>(qualityLevels));

        int currentQualityIndex = QualitySettings.GetQualityLevel();
        qualityDropdown.value = currentQualityIndex;
        qualityDropdown.RefreshShownValue();
    }
    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index, false);
    }
}
