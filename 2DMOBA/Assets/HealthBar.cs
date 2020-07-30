using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text healthBarText;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    private int maxHealth;
    private int currentHealth;
    // Start is called before the first frame update
    public void SetMaxHealth(float health)
    {
        maxHealth = (int)health;
        slider.maxValue = maxHealth;

        fill.color = gradient.Evaluate(1f);
        

    }
    public void SetHealth(float health)
    {
        currentHealth = (int)health;
        slider.value = currentHealth;
        fill.color = gradient.Evaluate(slider.normalizedValue);
        setText(currentHealth, maxHealth);
    }
    void setText(int currentHealth, int maxHealth)
    {
        healthBarText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
    }
}
