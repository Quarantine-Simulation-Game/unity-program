using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
[Serializable]
public class PlayerCondition
{
    public ItemType name = ItemType.Any;

    public int requiredLevel = 0;

    public int maximumValue = 20;

    public float currentValue = 20;

    public float dailyChangeValue = -1;
    
    public float nextDayChangeValue = -1;

    public GameObject Visualizer;

    public bool isActive = false;

 [SerializeField] GameObject text;

    // + -> add -> minus
    public void NewDay()
    {
        // if the condition is activated, then calculate daily changes
        if (isActive)
        {
            if (currentValue + dailyChangeValue >= 0 && currentValue + dailyChangeValue <= maximumValue)
                currentValue += nextDayChangeValue;
            else if (currentValue + dailyChangeValue > maximumValue)
            {
                currentValue = maximumValue;
            }
            
            if (Visualizer.GetComponent<Slider>() != null)
            {
                Visualizer.GetComponent<Slider>().value = currentValue;
                Visualizer.GetComponent<Slider>().maxValue = maximumValue;
            }
            UpdateText();
                       
        }
        ResetNextDayChangeValue();
    }

    public void ResetNextDayChangeValue()
    {
        nextDayChangeValue = dailyChangeValue;
    }
    public void ChangeToNextDayChange(float change)
    {
        nextDayChangeValue += change;
    }

    public void UpdateText()
    {
        if (text.GetComponent<TextVisualization>() != null)
        {
            text.GetComponent<TextVisualization>().TextUpdate(currentValue+"",maximumValue+"");
        }
    }
}
    
