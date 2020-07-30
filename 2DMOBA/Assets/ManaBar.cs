using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Text manaBarText;
    public Slider slider;
    private int maxMana;
    private int currentMana;
    // Start is called before the first frame update
    public void SetMaxMana(float mana)
    {
        maxMana = (int)mana;
        slider.maxValue = maxMana;

    }
    public void SetMana(float mana)
    {
            currentMana = (int)mana;
            slider.value = currentMana;
            setText(currentMana, maxMana);
        
    }
    void setText(int currentMana, int maxMana)
    {
        manaBarText.text = currentMana.ToString() + "/" + maxMana.ToString();
    }
}
