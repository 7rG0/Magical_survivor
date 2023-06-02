using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemPickUpObject : MonoBehaviour, IPickUpObject
{
    [SerializeField] private int amount;
    [SerializeField] private int count;
    public void OnPickUp(Player character)
    {
        character.level.AddExperiance(amount);
        character.gems.Add(count);
    }
}
