using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ItemData
{
    public float score;
    public float hp;
    public GameObject shadow;
}

public enum ItemType
{
    None,
    Ex0,
    Ex1,
    Ex2,
    HealingPotion,
    Shadow
}
public abstract class Item : MonoBehaviour
{
    public ItemData id = new ItemData();
    public ItemType ItemType = ItemType.None;
    public abstract void Initialize();
}
