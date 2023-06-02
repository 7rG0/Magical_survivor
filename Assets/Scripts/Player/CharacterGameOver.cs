using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    private Rigidbody2D rigid;

    [SerializeField] private GameObject weaponParent;

    public void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    public void GameOver() 
    {
        rigid.simulated = false; // мобы больше не толкают персонажа после смерти
        MagicSurvivor.magicSurvivorS.FinishGame();
        GetComponent<PlayerMovement>().enabled = false;
        gameOverPanel.SetActive(true);
        
        weaponParent.SetActive(false);
    }
}
