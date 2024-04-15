using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int Level = 0;

    [SerializeField] private Animator[] wallAnimators;

    public void OpenNewLevel()
    {
        wallAnimators[Level].SetTrigger("Close");
        wallAnimators[Level + 1].SetTrigger("Open");
    }

    public void RestartLevel()
    {
        Player.Instance.isSpawned = true;
    }
}
