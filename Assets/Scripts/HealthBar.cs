using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Text text;

    public void SetHealth(float health)
    {
        slider.value = health;
        text.text = health.ToString();
    }
}
