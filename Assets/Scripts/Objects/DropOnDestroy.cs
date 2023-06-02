using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] private GameObject dropItemPrefab;
    [SerializeField] [Range(0f,1f)] private float chance = 1f;

    private bool isQutting = false;

    private void OnApplicationQuit()
    {
        isQutting = true;
    }

    public void CheckDrop()
    {
        if (isQutting) { return; }
        
        if (Random.value < chance) 
        {
            Transform t = Instantiate(dropItemPrefab).transform;
            t.position = transform.position;
        }
    }  
}
