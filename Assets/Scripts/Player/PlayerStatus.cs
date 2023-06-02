using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI[] textsKills;

    static public int playerKills = 0;
    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (textsKills != null)
        {
            foreach (TMPro.TextMeshProUGUI textKill in textsKills)
            {
                textKill.text = "Kills: " + playerKills;
            }
        }
    }
}
