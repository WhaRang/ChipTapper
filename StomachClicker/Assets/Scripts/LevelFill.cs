using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFill : MonoBehaviour
{
    public static LevelFill instance;
    public Slider slider;

    private void Awake()
    {
        if (instance == null)
            instance = this.gameObject.GetComponent<LevelFill>();
    }

    public void UpdateFill(int completedTasks, int tasksNeeded)
    {
        slider.minValue = 0;
        slider.maxValue = tasksNeeded;
        slider.value = completedTasks;
    }
}
