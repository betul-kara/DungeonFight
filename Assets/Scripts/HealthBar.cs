using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Text text;

    public void SetHealth(float health)
    {
        if (slider.value > 0)
        {
            slider.value = health;
            text.text = health.ToString();
        }
        else
        {
            slider.value = 0;
            text.text = "0";
        }
    }
}
