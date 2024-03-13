using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] private Animator[] doorAnimators;
    [HideInInspector] public int level = 0;

    private void Awake()
    {
        Instance = this;
    }

    public void OpenNewLevelDoor()
    {
        doorAnimators[level].SetTrigger("Close");
        doorAnimators[level + 1].SetTrigger("Open");
    }
}
