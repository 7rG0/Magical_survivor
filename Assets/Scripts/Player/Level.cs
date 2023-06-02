using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private int level = 1;
    private int experiance = 0;
    [SerializeField] ExperianceBar experianceBar;

    int To_LEVEL_UP
    {
        get
        {
            return level * 1000;
        }
    }

    private void Start()
    {
        experianceBar.UpdateExperianceSlider(experiance, To_LEVEL_UP);
        experianceBar.SetLevelText(level);
    }

    public void AddExperiance(int amount)
    {
        experiance += amount;
        CheckLevelUp();
        experianceBar.UpdateExperianceSlider(experiance, To_LEVEL_UP);
    }

    public void CheckLevelUp() 
    { 
        if (experiance >= To_LEVEL_UP)
        {
            experiance -= To_LEVEL_UP;
            level += 1;
            experianceBar.SetLevelText(level);
        }
    }


}
