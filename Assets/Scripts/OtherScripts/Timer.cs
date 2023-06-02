using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private int sec = -1;
    private int min = 0;
    private Coroutine timerCoroutine;
    [SerializeField] private TMPro.TextMeshProUGUI timertext;
    void Start()
    {
        timerCoroutine = StartCoroutine(TimeFlow());
    }

    IEnumerator TimeFlow()
    {
        while (true) 
        {
            if(sec == 59)
            {
                min++;
                sec = -1;
            }
            sec++;
            timertext.text = min.ToString("D2") + ":" + sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }
    public void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }
}
