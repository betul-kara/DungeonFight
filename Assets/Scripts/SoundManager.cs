using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider masterSlider, musicSlider, sfxSlider;
    [SerializeField] AudioMixer audioMixer;
    private void Start()
    {
        LoadPlayerPrefs();
    }
    private void OnDestroy()
    {
        SavePlayerPrefs();
    }

    private void LoadPlayerPrefs()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.5f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
    }

    private void SavePlayerPrefs()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);

        PlayerPrefs.Save();
    }
    public void MasterValue()
    {
        audioMixer.SetFloat("master", Mathf.Log10(masterSlider.value) * 20);
    }
    public void MusicValue()
    {
        audioMixer.SetFloat("music", Mathf.Log10(musicSlider.value) * 20);
    }
    public void SoundEffectValue()
    {
        audioMixer.SetFloat("sfx", Mathf.Log10(sfxSlider.value) * 20);
    }
    public void ResetValue()
    {
        masterSlider.value = 0.5f;
        musicSlider.value = 0.5f;
        sfxSlider.value = 1f;

        SavePlayerPrefs();
    }
}
