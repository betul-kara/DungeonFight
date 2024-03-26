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
        Player.Instance.health += 20;
        SetButtonAttributes(false, disableColor);
        buttons[0].GetComponent<Animator>().SetTrigger("Purchased");
    }

    public void UpgradeAttack()
    {
        SetButtonAttributes(false, disableColor);
        buttons[1].GetComponent<Animator>().SetTrigger("Purchased");
    }

    public void UpgradeShield()
    {
        SetButtonAttributes(false, disableColor);
        buttons[2].GetComponent<Animator>().SetTrigger("Purchased");
    }

    private void SetButtonAttributes(bool isInteractable, Color color)
    {
        foreach (var button in buttons)
        {
            button.interactable = isInteractable;
            button.GetComponent<Image>().color = color;
        }
    }
}
