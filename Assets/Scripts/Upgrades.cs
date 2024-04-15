using System;
using UnityEngine;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    [SerializeField] private Button[] buttons;

    [SerializeField] private Color enableColor;
    [SerializeField] private Color disableColor;

    private void OnEnable()
    {
        SetButtonAttributes(true, enableColor);
    }

    public void UpgradeHealth()
    {
        Player.Instance.maxHealth += 20;
        Player.Instance.UpdatePlayerHealthBar();
    }

    public void UpgradeAttack()
    {
        float currentEnemyDamage = PlayerPrefs.GetFloat("EnemyDamage", 20f);
        PlayerPrefs.SetFloat("EnemyDamage", currentEnemyDamage + 10);
    }

    public void ReduceEnemySpawnTime()
    {
        SpawnManager.spawnInterval += 2f;
    }

    public void SetButtonAttributesToDisable()
    {
        SetButtonAttributes(false, disableColor);
    }

    public void PurchasedTrigger(Animator animator)
    {
        animator.SetTrigger("Purchased");
    }

    private void SetButtonAttributes(bool isInteractable, Color color)
    {
        foreach (var button in buttons)
        {
            button.interactable = isInteractable;
            button.GetComponent<Image>().color = color;
            button.GetComponent<Animator>().SetTrigger("Normal");
        }
    }
}
