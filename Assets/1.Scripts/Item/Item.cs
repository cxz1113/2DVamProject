using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public struct ItemData
{
    public float score;
    public float hp;
    public GameObject obj;
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
    public ItemType ItemType;
    public abstract void Initialize();

    public void ItemSelect()
    {
        switch(ItemType)
        {
            case ItemType.Ex0:
                GameControllerManager.instance.player.pd.curExperience += id.score;
                break;
            case ItemType.Ex1:
                GameControllerManager.instance.player.pd.curExperience += id.score;
                break;
            case ItemType.Ex2:
                GameControllerManager.instance.player.pd.curExperience += id.score;
                break;
            case ItemType.HealingPotion:
                if (GameControllerManager.instance.player.pd.curHp >= GameControllerManager.instance.player.pd.maxHp)
                    return;
                GameControllerManager.instance.player.pd.curHp += id.hp;
                break;
            case ItemType.Shadow:
                GameControllerManager.instance.player.GetComponent<Image>().color = new Color(255, 255, 255, 100 / 255);
                break;
        }
    }
}
