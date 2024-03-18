using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] private Animator[] wallAnimators;
    [HideInInspector] public int level = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenNewLevel()
    {
        wallAnimators[level].SetTrigger("Close");
        wallAnimators[level + 1].SetTrigger("Open");
    }

    public void RestartLevel()
    {
        print("restarting level...");
    }
}
