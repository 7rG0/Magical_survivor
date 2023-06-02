using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour
{
    public int gemAcquired;
    [SerializeField] private TMPro.TextMeshProUGUI gemsCountText;

    public void Add(int count) 
    {
        gemAcquired += count;
        gemsCountText.text = "Gems:" + gemAcquired.ToString();
    }
}
